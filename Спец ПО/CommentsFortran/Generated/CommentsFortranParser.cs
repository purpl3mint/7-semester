//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.9.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from CommentsFortran.g4 by ANTLR 4.9.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419


         using System;
         using System.Collections;

using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.9.2")]
[System.CLSCompliant(false)]
public partial class CommentsFortranParser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		STAR=1, LETTER=2, DIGIT=3, SPLITTER=4, ENDOFLINE=5;
	public const int
		RULE_prog = 0, RULE_comment = 1, RULE_correct = 2, RULE_error = 3;
	public static readonly string[] ruleNames = {
		"prog", "comment", "correct", "error"
	};

	private static readonly string[] _LiteralNames = {
		null, "'*'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "STAR", "LETTER", "DIGIT", "SPLITTER", "ENDOFLINE"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "CommentsFortran.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static CommentsFortranParser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}


	          Hashtable memory = new Hashtable();

		public CommentsFortranParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public CommentsFortranParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	public partial class ProgContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public CommentContext[] comment() {
			return GetRuleContexts<CommentContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public CommentContext comment(int i) {
			return GetRuleContext<CommentContext>(i);
		}
		public ProgContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_prog; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ICommentsFortranListener typedListener = listener as ICommentsFortranListener;
			if (typedListener != null) typedListener.EnterProg(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ICommentsFortranListener typedListener = listener as ICommentsFortranListener;
			if (typedListener != null) typedListener.ExitProg(this);
		}
	}

	[RuleVersion(0)]
	public ProgContext prog() {
		ProgContext _localctx = new ProgContext(Context, State);
		EnterRule(_localctx, 0, RULE_prog);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 9;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			do {
				{
				{
				State = 8;
				comment();
				}
				}
				State = 11;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			} while ( (((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << STAR) | (1L << LETTER) | (1L << DIGIT) | (1L << SPLITTER) | (1L << ENDOFLINE))) != 0) );
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class CommentContext : ParserRuleContext {
		public CorrectContext _correct;
		public ErrorContext _error;
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode STAR() { return GetToken(CommentsFortranParser.STAR, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public CorrectContext correct() {
			return GetRuleContext<CorrectContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ErrorContext error() {
			return GetRuleContext<ErrorContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode LETTER() { return GetToken(CommentsFortranParser.LETTER, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode DIGIT() { return GetToken(CommentsFortranParser.DIGIT, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode SPLITTER() { return GetToken(CommentsFortranParser.SPLITTER, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode ENDOFLINE() { return GetToken(CommentsFortranParser.ENDOFLINE, 0); }
		public CommentContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_comment; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ICommentsFortranListener typedListener = listener as ICommentsFortranListener;
			if (typedListener != null) typedListener.EnterComment(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ICommentsFortranListener typedListener = listener as ICommentsFortranListener;
			if (typedListener != null) typedListener.ExitComment(this);
		}
	}

	[RuleVersion(0)]
	public CommentContext comment() {
		CommentContext _localctx = new CommentContext(Context, State);
		EnterRule(_localctx, 2, RULE_comment);
		int _la;
		try {
			State = 24;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case STAR:
				EnterOuterAlt(_localctx, 1);
				{
				{
				State = 13;
				Match(STAR);
				State = 14;
				_localctx._correct = correct();
				}
				 Console.WriteLine(_localctx._correct.value); 
				}
				break;
			case LETTER:
			case DIGIT:
			case SPLITTER:
				EnterOuterAlt(_localctx, 2);
				{
				{
				State = 18;
				_la = TokenStream.LA(1);
				if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << LETTER) | (1L << DIGIT) | (1L << SPLITTER))) != 0)) ) {
				ErrorHandler.RecoverInline(this);
				}
				else {
					ErrorHandler.ReportMatch(this);
				    Consume();
				}
				State = 19;
				_localctx._error = error();
				}
				 Console.WriteLine(_localctx._error.value); 
				}
				break;
			case ENDOFLINE:
				EnterOuterAlt(_localctx, 3);
				{
				State = 23;
				Match(ENDOFLINE);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class CorrectContext : ParserRuleContext {
		public string value;
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode ENDOFLINE() { return GetToken(CommentsFortranParser.ENDOFLINE, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode[] LETTER() { return GetTokens(CommentsFortranParser.LETTER); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode LETTER(int i) {
			return GetToken(CommentsFortranParser.LETTER, i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode[] DIGIT() { return GetTokens(CommentsFortranParser.DIGIT); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode DIGIT(int i) {
			return GetToken(CommentsFortranParser.DIGIT, i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode[] SPLITTER() { return GetTokens(CommentsFortranParser.SPLITTER); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode SPLITTER(int i) {
			return GetToken(CommentsFortranParser.SPLITTER, i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode[] STAR() { return GetTokens(CommentsFortranParser.STAR); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode STAR(int i) {
			return GetToken(CommentsFortranParser.STAR, i);
		}
		public CorrectContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_correct; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ICommentsFortranListener typedListener = listener as ICommentsFortranListener;
			if (typedListener != null) typedListener.EnterCorrect(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ICommentsFortranListener typedListener = listener as ICommentsFortranListener;
			if (typedListener != null) typedListener.ExitCorrect(this);
		}
	}

	[RuleVersion(0)]
	public CorrectContext correct() {
		CorrectContext _localctx = new CorrectContext(Context, State);
		EnterRule(_localctx, 4, RULE_correct);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 29;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << STAR) | (1L << LETTER) | (1L << DIGIT) | (1L << SPLITTER))) != 0)) {
				{
				{
				State = 26;
				_la = TokenStream.LA(1);
				if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << STAR) | (1L << LETTER) | (1L << DIGIT) | (1L << SPLITTER))) != 0)) ) {
				ErrorHandler.RecoverInline(this);
				}
				else {
					ErrorHandler.ReportMatch(this);
				    Consume();
				}
				}
				}
				State = 31;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			State = 32;
			Match(ENDOFLINE);
			 _localctx.value =  "Correct"; 
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ErrorContext : ParserRuleContext {
		public string value;
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode ENDOFLINE() { return GetToken(CommentsFortranParser.ENDOFLINE, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode[] LETTER() { return GetTokens(CommentsFortranParser.LETTER); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode LETTER(int i) {
			return GetToken(CommentsFortranParser.LETTER, i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode[] DIGIT() { return GetTokens(CommentsFortranParser.DIGIT); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode DIGIT(int i) {
			return GetToken(CommentsFortranParser.DIGIT, i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode[] SPLITTER() { return GetTokens(CommentsFortranParser.SPLITTER); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode SPLITTER(int i) {
			return GetToken(CommentsFortranParser.SPLITTER, i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode[] STAR() { return GetTokens(CommentsFortranParser.STAR); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode STAR(int i) {
			return GetToken(CommentsFortranParser.STAR, i);
		}
		public ErrorContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_error; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ICommentsFortranListener typedListener = listener as ICommentsFortranListener;
			if (typedListener != null) typedListener.EnterError(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ICommentsFortranListener typedListener = listener as ICommentsFortranListener;
			if (typedListener != null) typedListener.ExitError(this);
		}
	}

	[RuleVersion(0)]
	public ErrorContext error() {
		ErrorContext _localctx = new ErrorContext(Context, State);
		EnterRule(_localctx, 6, RULE_error);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 38;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << STAR) | (1L << LETTER) | (1L << DIGIT) | (1L << SPLITTER))) != 0)) {
				{
				{
				State = 35;
				_la = TokenStream.LA(1);
				if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << STAR) | (1L << LETTER) | (1L << DIGIT) | (1L << SPLITTER))) != 0)) ) {
				ErrorHandler.RecoverInline(this);
				}
				else {
					ErrorHandler.ReportMatch(this);
				    Consume();
				}
				}
				}
				State = 40;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			State = 41;
			Match(ENDOFLINE);
			 _localctx.value =  "Error"; 
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x3', '\a', '/', '\x4', '\x2', '\t', '\x2', '\x4', '\x3', '\t', 
		'\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', '\x5', '\x3', '\x2', 
		'\x6', '\x2', '\f', '\n', '\x2', '\r', '\x2', '\xE', '\x2', '\r', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x5', '\x3', '\x1B', '\n', '\x3', '\x3', '\x4', '\a', '\x4', '\x1E', 
		'\n', '\x4', '\f', '\x4', '\xE', '\x4', '!', '\v', '\x4', '\x3', '\x4', 
		'\x3', '\x4', '\x3', '\x4', '\x3', '\x5', '\a', '\x5', '\'', '\n', '\x5', 
		'\f', '\x5', '\xE', '\x5', '*', '\v', '\x5', '\x3', '\x5', '\x3', '\x5', 
		'\x3', '\x5', '\x3', '\x5', '\x2', '\x2', '\x6', '\x2', '\x4', '\x6', 
		'\b', '\x2', '\x4', '\x3', '\x2', '\x4', '\x6', '\x3', '\x2', '\x3', '\x6', 
		'\x2', '/', '\x2', '\v', '\x3', '\x2', '\x2', '\x2', '\x4', '\x1A', '\x3', 
		'\x2', '\x2', '\x2', '\x6', '\x1F', '\x3', '\x2', '\x2', '\x2', '\b', 
		'(', '\x3', '\x2', '\x2', '\x2', '\n', '\f', '\x5', '\x4', '\x3', '\x2', 
		'\v', '\n', '\x3', '\x2', '\x2', '\x2', '\f', '\r', '\x3', '\x2', '\x2', 
		'\x2', '\r', '\v', '\x3', '\x2', '\x2', '\x2', '\r', '\xE', '\x3', '\x2', 
		'\x2', '\x2', '\xE', '\x3', '\x3', '\x2', '\x2', '\x2', '\xF', '\x10', 
		'\a', '\x3', '\x2', '\x2', '\x10', '\x11', '\x5', '\x6', '\x4', '\x2', 
		'\x11', '\x12', '\x3', '\x2', '\x2', '\x2', '\x12', '\x13', '\b', '\x3', 
		'\x1', '\x2', '\x13', '\x1B', '\x3', '\x2', '\x2', '\x2', '\x14', '\x15', 
		'\t', '\x2', '\x2', '\x2', '\x15', '\x16', '\x5', '\b', '\x5', '\x2', 
		'\x16', '\x17', '\x3', '\x2', '\x2', '\x2', '\x17', '\x18', '\b', '\x3', 
		'\x1', '\x2', '\x18', '\x1B', '\x3', '\x2', '\x2', '\x2', '\x19', '\x1B', 
		'\a', '\a', '\x2', '\x2', '\x1A', '\xF', '\x3', '\x2', '\x2', '\x2', '\x1A', 
		'\x14', '\x3', '\x2', '\x2', '\x2', '\x1A', '\x19', '\x3', '\x2', '\x2', 
		'\x2', '\x1B', '\x5', '\x3', '\x2', '\x2', '\x2', '\x1C', '\x1E', '\t', 
		'\x3', '\x2', '\x2', '\x1D', '\x1C', '\x3', '\x2', '\x2', '\x2', '\x1E', 
		'!', '\x3', '\x2', '\x2', '\x2', '\x1F', '\x1D', '\x3', '\x2', '\x2', 
		'\x2', '\x1F', ' ', '\x3', '\x2', '\x2', '\x2', ' ', '\"', '\x3', '\x2', 
		'\x2', '\x2', '!', '\x1F', '\x3', '\x2', '\x2', '\x2', '\"', '#', '\a', 
		'\a', '\x2', '\x2', '#', '$', '\b', '\x4', '\x1', '\x2', '$', '\a', '\x3', 
		'\x2', '\x2', '\x2', '%', '\'', '\t', '\x3', '\x2', '\x2', '&', '%', '\x3', 
		'\x2', '\x2', '\x2', '\'', '*', '\x3', '\x2', '\x2', '\x2', '(', '&', 
		'\x3', '\x2', '\x2', '\x2', '(', ')', '\x3', '\x2', '\x2', '\x2', ')', 
		'+', '\x3', '\x2', '\x2', '\x2', '*', '(', '\x3', '\x2', '\x2', '\x2', 
		'+', ',', '\a', '\a', '\x2', '\x2', ',', '-', '\b', '\x5', '\x1', '\x2', 
		'-', '\t', '\x3', '\x2', '\x2', '\x2', '\x6', '\r', '\x1A', '\x1F', '(',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
