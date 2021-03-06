﻿// *********************************************************
//
// Copyright © Microsoft Corporation
//
// Licensed under the Apache License, Version 2.0 (the
// "License"); you may not use this file except in
// compliance with the License. You may obtain a copy of
// the License at
//
// http://www.apache.org/licenses/LICENSE-2.0 
//
// THIS CODE IS PROVIDED ON AN *AS IS* BASIS, WITHOUT WARRANTIES
// OR CONDITIONS OF ANY KIND, EITHER EXPRESS OR IMPLIED,
// INCLUDING WITHOUT LIMITATION ANY IMPLIED WARRANTIES
// OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR
// PURPOSE, MERCHANTABILITY OR NON-INFRINGEMENT.
//
// See the Apache 2 License for the specific language
// governing permissions and limitations under the License.
//
// *********************************************************

using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Roslyn.Compilers;
using Roslyn.Compilers.CSharp;

namespace APISampleUnitTestsCS
{
    [TestClass]
    public class Parsing
    {
        [TestMethod]
        public void TextParseTreeRoundtrip()
        {
            string text = "class C { void M() { } } // exact text round trip, including comments and whitespace";
            SyntaxTree tree = SyntaxTree.ParseText(text);
            Assert.AreEqual(text, tree.ToString());
        }

        [TestMethod]
        public void DetermineValidIdentifierName()
        {
            ValidIdentifier("@class", true);
            ValidIdentifier("class", false);
        }

        private void ValidIdentifier(string identifier, bool expectedValid)
        {
            SyntaxToken token = Syntax.ParseToken(identifier);
            Assert.AreEqual(expectedValid,
                token.Kind == SyntaxKind.IdentifierToken && token.Span.Length == identifier.Length);
        }

        [TestMethod]
        public void SyntaxFactsMethods()
        {
            Assert.AreEqual("protected internal", SyntaxFacts.GetText(Accessibility.ProtectedInternal));
            Assert.AreEqual("??", SyntaxFacts.GetText(SyntaxKind.QuestionQuestionToken));
            Assert.AreEqual("this", SyntaxFacts.GetText(SyntaxKind.ThisKeyword));

            Assert.AreEqual(SyntaxKind.CharacterLiteralExpression, SyntaxFacts.GetLiteralExpression(SyntaxKind.CharacterLiteralToken));
            Assert.AreEqual(SyntaxKind.CoalesceExpression, SyntaxFacts.GetBinaryExpression(SyntaxKind.QuestionQuestionToken));
            Assert.AreEqual(SyntaxKind.None, SyntaxFacts.GetBinaryExpression(SyntaxKind.UndefDirectiveTrivia));
            Assert.AreEqual(false, SyntaxKind.StringLiteralToken.IsPunctuation());
        }

        [TestMethod]
        public void ParseTokens()
        {
            IEnumerable<SyntaxToken> tokens = Syntax.ParseTokens("class C { // trivia");
            IEnumerable<string> fullTexts = tokens.Select(token => token.ToFullString());

            Assert.IsTrue(fullTexts.SequenceEqual(new[]
            {
                "class ",
                "C ",
                "{ // trivia",
                "" // EOF
            }));
        }

        [TestMethod]
        public void ParseExpression()
        {
            ExpressionSyntax expression = Syntax.ParseExpression("1 + 2");
            if (expression.Kind == SyntaxKind.AddExpression)
            {
                BinaryExpressionSyntax binaryExpression = (BinaryExpressionSyntax)expression;
                SyntaxToken operatorToken = binaryExpression.OperatorToken;
                Assert.AreEqual("+", operatorToken.ToString());

                ExpressionSyntax left = binaryExpression.Left;
                Assert.AreEqual(SyntaxKind.NumericLiteralExpression, left.Kind);
            }
        }

        [TestMethod]
        public void IncrementalParse()
        {
            var oldText = new StringText("class C { }");
            var newText = oldText.WithChanges(new TextChange(new TextSpan(9, 0), "void M() { } "));
            
            SyntaxTree tree = SyntaxTree.ParseText(oldText);

            var newTree = tree.WithChangedText(newText);

            Assert.AreEqual(newText.ToString(), newTree.ToString());
        }

        [TestMethod]
        public void PreprocessorDirectives()
        {
            SyntaxTree tree = SyntaxTree.ParseText(@"#if true
class A { }
#else
class B { }
#endif");
            SyntaxToken eof = tree.GetRoot().FindToken(tree.GetText().Length, false);
            Assert.AreEqual(true, eof.HasLeadingTrivia);
            Assert.AreEqual(false, eof.HasTrailingTrivia);
            Assert.AreEqual(true, eof.ContainsDirectives);

            SyntaxTriviaList trivia = eof.LeadingTrivia;
            Assert.AreEqual(3, trivia.Count);
            Assert.AreEqual("#else", trivia[0].ToString());
            Assert.AreEqual(SyntaxKind.DisabledTextTrivia, trivia[1].Kind);
            Assert.AreEqual("#endif", trivia[2].ToString());

            DirectiveTriviaSyntax directive = tree.GetRoot().GetLastDirective();
            Assert.AreEqual("endif", directive.DirectiveNameToken.Value);

            directive = directive.GetPreviousDirective();
            Assert.AreEqual("else", directive.DirectiveNameToken.Value);

            // List<DirectiveSyntax> relatedDirectives = directive.GetRelatedDirectives();
            // Assert.AreEqual(3, relatedDirectives.Count);
        }
    }
}
