// ’
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDXWin {
    public class CLang {
        public enum EMode { JPN, ENG };

        private class CItem {
            private string JPN, ENG;
            public CItem(string _JPN, string _ENG) {
                JPN = _JPN;
                ENG = _ENG;
            }
            public string Get() {
                switch (CCommon.INI.LangMode) {
                    case EMode.JPN: return JPN;
                    case EMode.ENG: return ENG;
                    default: throw new Exception();
                }
            }
        }

        public enum EWInternet { TitleLbl, IPv6Lbl, UserNameLbl, AccountHintLbl, PermissionChk, CloseBtn_Yes, CloseBtn_No, };
        private static Dictionary<EWInternet, CItem> WInternetItems = new() {
            { EWInternet.TitleLbl, new CItem("インターネットを使用してもよろしいですか？", "Do you want to use the Internet?") },
            { EWInternet.IPv6Lbl, new CItem("接続先IPv6アドレス:", "Destination IPv6 address:") },
            { EWInternet.UserNameLbl, new CItem("ユーザー名:", "User name:") },
            { EWInternet.AccountHintLbl, new CItem("アカウント登録などはありませんので、名前は空のままで大丈夫です。", "You don’t need to register an account. You can leave the name blank.") },
            { EWInternet.PermissionChk, new CItem("インターネットの使用を許可する", "Allow internet use") },
            { EWInternet.CloseBtn_Yes, new CItem("許可して続行する", "Allow and continue") },
            { EWInternet.CloseBtn_No, new CItem("拒否して終了する", "Deny and quit") },
        };
        public static string GetWInternet(EWInternet e) {
            if (WInternetItems.ContainsKey(e)) { return WInternetItems[e].Get(); }
            return "WInternet: Language resource undefined.";
        }

        public enum EBoot {
            InputBoxDefText,
            WasapiError_Surround1, WasapiError_Surround2, WasapiError_192kHz1, WasapiError_192kHz2,
            Network_IlligalFormat, Network_InfoCantGet, Network_ServerStop1, Network_ServerStop2,
            Network_CantLogin1, Network_CantLogin2, Network_CantLogin3,
            Network_Logined1, Network_Logined2,
            MenuItemDef1, MenuItemDef2, MenuItemDef3, MenuItemDef4, MenuItemDef5, MenuItemDef6, MenuItemDef7, MenuItemDef8,
            CGROM_Loaded, CGROM_NotFound, CGROM_NotFoundForVisual1, CGROM_NotFoundForVisual2,
            OutputPathMsg1, OutputPathMsg2,
            PDXHQBos_Loaded,
            FatalErrorOnBoot,
            CurrentPath_Restore, CurrentPath_Error,
        };
        private static Dictionary<EBoot, CItem> BootItems = new() {
            { EBoot.InputBoxDefText, new CItem("コマンドを入力してください。（Helpなど）", "Please enter a command. (Help, etc.)") },
            { EBoot.WasapiError_Surround1, new CItem("WasapiOutでエラーを検出しました。サラウンド出力が開始できませんでした。", "An error was detected in WasapiOut. Surround output could not be started.") },
            { EBoot.WasapiError_Surround2, new CItem("画像ファイル [Documents/HowToSurround.png]", "See the image file [Documents/HowToSurround.png].") },
            { EBoot.WasapiError_192kHz1, new CItem("WasapiOutでエラーを検出しました。192kHz出力が開始できませんでした。", "An error was detected in WasapiOut. 192kHz output could not be started.") },
            { EBoot.WasapiError_192kHz2, new CItem("画像ファイル [Documents/HowTo192kHz.png]", "See the image file [Documents/HowTo192kHz.png].") },
            { EBoot.Network_IlligalFormat, new CItem("サーバ情報のフォーマットが違います。", "The format of the server information is incorrect.") },
            { EBoot.Network_InfoCantGet, new CItem("サーバ情報の取得に失敗しました。", "Failed to get the server information.") },
            { EBoot.Network_ServerStop1, new CItem("サーバが止まっているかもしれません。", "The server may be down.") },
            { EBoot.Network_ServerStop2, new CItem("MDXWin本体がバージョンアップしているかもしれません。", "MDXWin.exe may have been upgraded.") },
            { EBoot.Network_CantLogin1, new CItem("サーバにログインできませんでした。", "Failed to log in to the server.") },
            { EBoot.Network_CantLogin2, new CItem("サーバが止まっているかもしれません。", "The server may be down.") },
            { EBoot.Network_CantLogin3, new CItem("IPv6が使用可能なインターネット接続があるか確認してみてください。", "Please check if you have an internet connection that supports IPv6.") },
            { EBoot.Network_Logined1, new CItem("ユーザ名 [", "Logged in as user name[") },
            { EBoot.Network_Logined2, new CItem("] でログインしました。", "]") },
            { EBoot.MenuItemDef1, new CItem("ファイルセレクタ", "File selector") },
            { EBoot.MenuItemDef2, new CItem("ビジュアル", "Visual") },
            { EBoot.MenuItemDef3, new CItem("ドキュメント類", "Documents") },
            { EBoot.MenuItemDef4, new CItem("30%シーク", "Seek to 30%") },
            { EBoot.MenuItemDef5, new CItem("演奏停止", "Stop") },
            { EBoot.MenuItemDef6, new CItem("次の曲", "Next") },
            { EBoot.MenuItemDef7, new CItem("ユーザ定義(7)", "UserDef(7)") },
            { EBoot.MenuItemDef8, new CItem("ユーザ定義(8)", "UserDef(8)") },
            { EBoot.CGROM_Loaded, new CItem("CGROM.DATを読み込みました。", "CGROM.DAT has been loaded.") },
            { EBoot.CGROM_NotFound, new CItem("CGROM.DATが見つからなかったので、Windowsフォントで代替します。", "Using Windows fonts as a substitute because CGROM.DAT was not found.") },
            { EBoot.CGROM_NotFoundForVisual1, new CItem("CGROM.DATが見つからなかったので", "Using Windows substitute fonts,") }, // この項目は横幅に制限があるので変更不可 This item cannot be changed because it has a width limit.
            { EBoot.CGROM_NotFoundForVisual2, new CItem("Windowsフォントで代替します。", "because CGROM.DAT was not found.") }, // この項目は横幅に制限があるので変更不可 This item cannot be changed because it has a width limit.
            { EBoot.OutputPathMsg1, new CItem("出力パスを [", "Set the output path to [") },
            { EBoot.OutputPathMsg2, new CItem("] に設定しました。", "]") },
            { EBoot.PDXHQBos_Loaded, new CItem("を読み込みました。", "loaded.") },
            { EBoot.CurrentPath_Restore, new CItem("前回のカレントパスを復元しました。", "Restored the previous current path.") },
            { EBoot.CurrentPath_Error, new CItem("カレントパスの復元に失敗しました。ルートパスから再開しました。", "Failed to restore the current path. Restarted from the root path.") },
            { EBoot.FatalErrorOnBoot, new CItem("起動中に例外が発生しました。報告頂けたらありがたいです。", "An exception occurred during startup. I would appreciate it if you could report it.") },
        };
        public static string GetBoot(EBoot e) {
            if (BootItems.ContainsKey(e)) { return BootItems[e].Get(); }
            return "Boot: Language resource undefined.";
        }

        public enum EConsole {
            MDX_NoTitle,
            MDX_Exception1, MDX_Exception2, MDX_ExceptionOnPlay,
            MDX_Exception_Dialog,
            AudioThread_UndefBitDepth, AudioThread_MDXNotLoad, AudioThread_StillHaveSamplesInBuffer, AudioThread_SamplePeakClipped, AudioThread_EnabledWaveFileWriter, AudioThread_MDXFileHaveErrorSoSmallVolume,
            CGROM_DoubleSize, CGROM_UseWindowsFont,
        };
        private static Dictionary<EConsole, CItem> ConsoleItems = new() {
            { EConsole.MDX_NoTitle, new CItem("タイトルはありません。", "No title.") },
            { EConsole.MDX_Exception1, new CItem("エラーのあるMDXファイルです。", "This is an MDX file with errors.") },
            { EConsole.MDX_Exception2, new CItem("異常な発音があるかもしれないので、小さめの音量で再生します。", "Play with a low volume because there may be some abnormal sounds.") },
            { EConsole.MDX_ExceptionOnPlay, new CItem("エラーが発生したので演奏を中断しました。", "The performance was interrupted due to an error.") },
            { EConsole.MDX_Exception_Dialog, new CItem("＜中止＞ 再実行 ＜無視＞", "<Stop> Retry <Ignore>") },
            { EConsole.AudioThread_UndefBitDepth, new CItem("未定義ビット深度", "Undefined bit depth") },
            { EConsole.AudioThread_MDXNotLoad, new CItem("Thread error. MDXファイルが読み込まれていない。", "Thread error. No MDX file is loaded.") },
            { EConsole.AudioThread_StillHaveSamplesInBuffer, new CItem("Thread error. バッファにサンプルが残っている。", "Thread error. There are samples remaining in the buffer.") },
            { EConsole.AudioThread_SamplePeakClipped, new CItem("音割れが発生したので音量を下げました。", "I lowered the volume because of sound distortion.") },
            { EConsole.AudioThread_EnabledWaveFileWriter, new CItem("WaveFileWriterが有効になっています。", "WaveFileWriter is enabled.") },
            { EConsole.AudioThread_MDXFileHaveErrorSoSmallVolume, new CItem("エラーのあるMDXファイルです。異常音が出るかもしれないので小さめの音量で再生します。", "Play with a low volume because this is an MDX file with errors.") },
            { EConsole.CGROM_DoubleSize, new CItem("(2倍角)", "(double)") },
            { EConsole.CGROM_UseWindowsFont, new CItem("Windows代替フォント", "Windows substitute font") },
        };
        public static string GetConsole(EConsole e) {
            if (ConsoleItems.ContainsKey(e)) { return ConsoleItems[e].Get(); }
            return "Console: Language resource undefined.";
        }

        public enum ECommand {
            ParamError,
            SetFunc_FormatError, SetFunc_NumIsNotNum, SetFunc_NumIsOver,
            CantLoadMDX,
            PlayMode_Undef, PlayMode_Empty,
            EditAutoexecHint1, EditAutoexecHint2,
            ExecUndefFunc1, ExecUndefFunc2, Func_OverIndex,
            SetIgnoreException,
            ADPCMMode_NearestNeighborInterpolation, ADPCMMode_LinearInterpolation, ADPCMMode_CubicSplineInterpolation,
            Dir_File, Dir_Used,
            WrongParam, OutOfRange, NoLoadedMDX,
            VisualMul_Help, FS_Error, FS_Help, ADPCM_Help, MXLoop_Help, MXMute_WrongCh, MXSeek_Help, MXSeek_NoNum, SampleRate_Help, Output_NowPlaying, Volume_Help, NoCommandOrNoFilename,
        };
        private static Dictionary<ECommand, CItem> CommandItems = new() {
            { ECommand.ParamError, new CItem("パラメータが間違っています。", "The parameter is wrong.") },
            { ECommand.SetFunc_FormatError, new CItem("フォーマットが違います。", "The format is incorrect.") },
            { ECommand.SetFunc_NumIsNotNum, new CItem("機能番号が数字ではありません。", "The function number is not a digit.") },
            { ECommand.SetFunc_NumIsOver, new CItem("機能番号が範囲外です。", "The function number is out of range.") },
            { ECommand.CantLoadMDX, new CItem("ファイルが読み込めません。", "Cannot read file.") },
            { ECommand.PlayMode_Undef, new CItem("未定義モードです。 ", "Undefined mode.") },
            { ECommand.PlayMode_Empty, new CItem("プレイリストが空です。", "Playlist is empty.") },
            { ECommand.EditAutoexecHint1, new CItem("現在の環境をクリップボードにコピーしました。", "Copied the current environment to the clipboard.") },
            { ECommand.EditAutoexecHint2, new CItem("autoexec.txt を書き換えてご使用ください。", "Please edit autoexec.txt and use it.") },
            { ECommand.ExecUndefFunc1, new CItem("未定義のショートカット機能です。", "Undefined shortcut function.") },
            { ECommand.ExecUndefFunc2, new CItem("Helpコマンドを実行して、SetFuncコマンドを参照してください。", "Please run the Help command and refer to the SetFunc command.") },
            { ECommand.Func_OverIndex, new CItem("範囲外のコマンドの情報を取得しようとしました。", "Tried to get information for a command out of range.") },
            { ECommand.SetIgnoreException, new CItem("続行可能な例外を無視するように設定しました。", "Set to ignore continuable exceptions.") },
            { ECommand.ADPCMMode_NearestNeighborInterpolation, new CItem("最近傍補間", "Nearest neighbor interpolation") },
            { ECommand.ADPCMMode_LinearInterpolation, new CItem("線形補間", "Linear interpolation") },
            { ECommand.ADPCMMode_CubicSplineInterpolation, new CItem("三次スプライン補間", "Cubic spline interpolation") },
            { ECommand.Dir_File, new CItem("ファイル", "file(s)") },
            { ECommand.Dir_Used, new CItem("使用", "used") },
            { ECommand.WrongParam, new CItem("パラメータが間違っています。", "The parameter is incorrect.") },
            { ECommand.OutOfRange, new CItem("設定範囲外です。", "Out of setting range.") },
            { ECommand.NoLoadedMDX, new CItem("MDXファイルが読み込まれていません。", "No MDX file is loaded.") },
            { ECommand.VisualMul_Help, new CItem("表示倍率を指定してください。", "Please specify the display magnification.") },
            { ECommand.FS_Error, new CItem("フォントサイズの設定に失敗しました。", "Failed to set the font size.") },
            { ECommand.FS_Help, new CItem("フォントサイズを指定してください。", "Please specify the font size.") },
            { ECommand.ADPCM_Help, new CItem("アップサンプリングモードを指定してください。", "Please specify the upsampling mode.") },
            { ECommand.MXLoop_Help, new CItem("ループ回数を指定してください。", "Please specify the number of loops.") },
            { ECommand.MXMute_WrongCh, new CItem("チャンネルの指定が異常です。", "The channel specification is invalid.") },
            { ECommand.MXSeek_Help, new CItem("秒数または割合（数値%）を指定してください。", "Please specify the seconds or percentage. (When using percentages, add the % character at the end.)") },
            { ECommand.MXSeek_NoNum, new CItem("数値ではありません。", "It’s not a numeric value.") },
            { ECommand.SampleRate_Help, new CItem("レンダリング周波数を指定してください。", "Please specify the rendering frequency.") },
            { ECommand.Output_NowPlaying, new CItem("再生中は設定を変更できません。", "You cannot change the settings while playing.") },
            { ECommand.Volume_Help, new CItem("音量を指定してください。", "Please specify the volume.") },
            { ECommand.NoCommandOrNoFilename, new CItem("コマンドまたはファイル名が違います。", "It’s not a valid command or file name.") },
        };
        public static string GetCommand(ECommand e) {
            if (CommandItems.ContainsKey(e)) { return CommandItems[e].Get(); }
            return "Command: Language resource undefined.";
        }

        public static List<MainWindow.CLog.CItem> GetCommandHelp() {
            var res = new List<MainWindow.CLog.CItem>();
            switch (CCommon.INI.LangMode) {
                case EMode.JPN:
                    res.Add(new MainWindow.CLog.CItem("・システム関連"));
                    res.Add(new MainWindow.CLog.CItem("CD [パス名]        現在のディレクトリを表示または変更します。", MainWindow.CLog.CItem.EMode.Command, "CD"));
                    res.Add(new MainWindow.CLog.CItem("DIR                ディレクトリ中のファイルやサブディレクトリの一覧を表示します。", MainWindow.CLog.CItem.EMode.Command, "DIR"));
                    res.Add(new MainWindow.CLog.CItem("DOCVIEW [ON|OFF]   付属ドキュメント閲覧ウィンドウを表示または非表示に変更します。", MainWindow.CLog.CItem.EMode.Command, "DOCVIEW"));
                    res.Add(new MainWindow.CLog.CItem("EXIT               アプリケーションを終了します。", MainWindow.CLog.CItem.EMode.Command, "EXIT"));
                    res.Add(new MainWindow.CLog.CItem("FILESEL [ON|OFF]   ファイルセレクタを表示または非表示に変更します。", MainWindow.CLog.CItem.EMode.Command, "FILESEL"));
                    res.Add(new MainWindow.CLog.CItem("IGEXCEPT [ON|OFF]  演奏続行可能なエラーを無視するよう設定します。", MainWindow.CLog.CItem.EMode.Command, "IGEXCEPT"));
                    res.Add(new MainWindow.CLog.CItem("PLAYMODE [Mode]    再生順序を設定します。Single=単曲停止, Repeat=単曲繰り返し, Normal=順再生, Random=ランダム再生", MainWindow.CLog.CItem.EMode.Command, "PLAYMODE"));
                    res.Add(new MainWindow.CLog.CItem("PLAYNEXT           次の曲を再生します。", MainWindow.CLog.CItem.EMode.Command, "PLAYNEXT"));
                    res.Add(new MainWindow.CLog.CItem("SETFUNC [番号, 名前, コマンド] メニューのショートカット機能を設定します。(8個まで)", MainWindow.CLog.CItem.EMode.Command, "SETFUNC"));
                    res.Add(new MainWindow.CLog.CItem("                   SetFunc 1, 停止, mxstop のように指定してください。"));
                    res.Add(new MainWindow.CLog.CItem("VISUAL [ON|OFF]    現在の再生状況を表示または非表示に変更します。", MainWindow.CLog.CItem.EMode.Command, "VISUAL"));
                    res.Add(new MainWindow.CLog.CItem("VISUALMUL [0.5～4] 再生状況ウィンドウの表示倍率を設定します。", MainWindow.CLog.CItem.EMode.Command, "VISUALMUL"));
                    res.Add(new MainWindow.CLog.CItem("SPEANA [ON|OFF]    再生状況ウィンドウのスペアナを表示または非表示に変更します。", MainWindow.CLog.CItem.EMode.Command, "SPEANA"));
                    res.Add(new MainWindow.CLog.CItem(""));
                    res.Add(new MainWindow.CLog.CItem("・フォント関連"));
                    res.Add(new MainWindow.CLog.CItem("CONSOLEFS [数値]   この画面のフォントサイズを設定します。", MainWindow.CLog.CItem.EMode.Command, "CONSOLEFS"));
                    res.Add(new MainWindow.CLog.CItem("FILESELFS [数値]   ファイルセレクタのフォントサイズを設定します。", MainWindow.CLog.CItem.EMode.Command, "FILESELFS"));
                    res.Add(new MainWindow.CLog.CItem("                   16=8x16, 24=12x24, 32=8x16(2倍角), 48=12x24(2倍角)"));
                    res.Add(new MainWindow.CLog.CItem(""));
                    res.Add(new MainWindow.CLog.CItem("・MXDRV関連"));
                    res.Add(new MainWindow.CLog.CItem("ADPCM [0|1|2]      ADPCMのアップサンプリングモードを設定します。", MainWindow.CLog.CItem.EMode.Command, "ADPCM"));
                    res.Add(new MainWindow.CLog.CItem("                   0=最近傍補間, 1=線形補間, 2=三次スプライン補間."));
                    res.Add(new MainWindow.CLog.CItem("BOSPDXHQ [ON|OFF]  高音質版bos.pdxの使用を設定します。", MainWindow.CLog.CItem.EMode.Command, "BOSPDXHQ"));
                    res.Add(new MainWindow.CLog.CItem("MXFADE             フェードアウトします。", MainWindow.CLog.CItem.EMode.Command, "MXFADE"));
                    res.Add(new MainWindow.CLog.CItem("MXLOOP [数値]      ループ回数を設定します。", MainWindow.CLog.CItem.EMode.Command, "MXLOOP"));
                    res.Add(new MainWindow.CLog.CItem("MXMUTE [Channel]   チャンネルミュートを切り替えます。[1-16|A-H|P-W|ALL]", MainWindow.CLog.CItem.EMode.Command, "MXMUTE"));
                    res.Add(new MainWindow.CLog.CItem("MXOPM [ON|OFF]     OPM出力を設定します。", MainWindow.CLog.CItem.EMode.Command, "MXOPM"));
                    res.Add(new MainWindow.CLog.CItem("MXPCM [ON|OFF]     PCM(PCM8)出力を設定します。", MainWindow.CLog.CItem.EMode.Command, "MXPCM"));
                    res.Add(new MainWindow.CLog.CItem("MXP [ファイル名]   指定されたMDXファイルを再生します。（拡張子省略可能）", MainWindow.CLog.CItem.EMode.Command, "MXP"));
                    res.Add(new MainWindow.CLog.CItem("MXSEEK [秒数]      再生中のMDXファイルの再生位置を変更します。", MainWindow.CLog.CItem.EMode.Command, "MXSEEK"));
                    res.Add(new MainWindow.CLog.CItem("MXSTAT             再生中のMDXファイルの情報を表示します。", MainWindow.CLog.CItem.EMode.Command, "MXSTAT"));
                    res.Add(new MainWindow.CLog.CItem("MXSTOP             再生を停止します。", MainWindow.CLog.CItem.EMode.Command, "MXSTOP"));
                    res.Add(new MainWindow.CLog.CItem("SAMPLERATE [Hz]    レンダリング周波数を設定します。(62500～384000Hz)", MainWindow.CLog.CItem.EMode.Command, "SAMPLERATE"));
                    res.Add(new MainWindow.CLog.CItem(""));
                    res.Add(new MainWindow.CLog.CItem("・音声出力関連"));
                    res.Add(new MainWindow.CLog.CItem("OUTPUT [ON|OFF]    LogファイルとWaveファイル出力を設定します。", MainWindow.CLog.CItem.EMode.Command, "OUTPUT"));
                    res.Add(new MainWindow.CLog.CItem("VOLUME [数値]      出力音量を設定します。dB単位で70～100の範囲です。", MainWindow.CLog.CItem.EMode.Command, "VOLUME"));
                    res.Add(new MainWindow.CLog.CItem(""));
                    res.Add(new MainWindow.CLog.CItem("コマンド及びファイル名は大文字小文字を区別しません。"));
                    res.Add(new MainWindow.CLog.CItem("パラメータはひとつだけなので、スペースを含むファイル名でもダブルクォーテーション不要です。"));
                    break;
                case EMode.ENG:
                    res.Add(new MainWindow.CLog.CItem("+ System class"));
                    res.Add(new MainWindow.CLog.CItem("CD [Path]          Displays or changes the current directory.", MainWindow.CLog.CItem.EMode.Command, "CD"));
                    res.Add(new MainWindow.CLog.CItem("DIR                Displays a list of files and subdirectories in the directory.", MainWindow.CLog.CItem.EMode.Command, "DIR"));
                    res.Add(new MainWindow.CLog.CItem("DOCVIEW [ON|OFF]   Shows or hides the attached document viewer window.", MainWindow.CLog.CItem.EMode.Command, "DOCVIEW"));
                    res.Add(new MainWindow.CLog.CItem("EXIT               Exits the application.", MainWindow.CLog.CItem.EMode.Command, "EXIT"));
                    res.Add(new MainWindow.CLog.CItem("FILESEL [ON|OFF]   Shows or hides the file selector window.", MainWindow.CLog.CItem.EMode.Command, "FILESEL"));
                    res.Add(new MainWindow.CLog.CItem("IGEXCEPT [ON|OFF]  Sets to ignore errors that can be continued playing.", MainWindow.CLog.CItem.EMode.Command, "IGEXCEPT"));
                    res.Add(new MainWindow.CLog.CItem("PLAYMODE [Mode]    Sets the playback order. Single=Single stop, Repeat=Single repeat, Normal=Sequential play, Random=Random play", MainWindow.CLog.CItem.EMode.Command, "PLAYMODE"));
                    res.Add(new MainWindow.CLog.CItem("PLAYNEXT           Plays the next song.", MainWindow.CLog.CItem.EMode.Command, "PLAYNEXT"));
                    res.Add(new MainWindow.CLog.CItem("SETFUNC [Num, Name, Command] Configures shortcut functions in the menu. (Up to 8 items)", MainWindow.CLog.CItem.EMode.Command, "SETFUNC"));
                    res.Add(new MainWindow.CLog.CItem("                             Example: SetFunc 1, STOP, mxstop"));
                    res.Add(new MainWindow.CLog.CItem("VISUAL [ON|OFF]    Shows or hides the current playback status.", MainWindow.CLog.CItem.EMode.Command, "VISUAL"));
                    res.Add(new MainWindow.CLog.CItem("VISUALMUL [0.5～4] Sets the display magnification of the playback status window.", MainWindow.CLog.CItem.EMode.Command, "VISUALMUL"));
                    res.Add(new MainWindow.CLog.CItem("SPEANA [ON|OFF]    Shows or hides the spectrum analyzer in the playback status window.", MainWindow.CLog.CItem.EMode.Command, "SPEANA"));
                    res.Add(new MainWindow.CLog.CItem(""));
                    res.Add(new MainWindow.CLog.CItem("+ Font class"));
                    res.Add(new MainWindow.CLog.CItem("CONSOLEFS [Size]   Sets the font size for this screen.", MainWindow.CLog.CItem.EMode.Command, "CONSOLEFS"));
                    res.Add(new MainWindow.CLog.CItem("FILESELFS [Size]   Sets the font size for the file selector.", MainWindow.CLog.CItem.EMode.Command, "FILESELFS"));
                    res.Add(new MainWindow.CLog.CItem("                   16=8x16, 24=12x24, 32=8x16 (double), 48=12x24 (double)"));
                    res.Add(new MainWindow.CLog.CItem(""));
                    res.Add(new MainWindow.CLog.CItem("+ MXDRV class"));
                    res.Add(new MainWindow.CLog.CItem("ADPCM [0|1|2]      Sets the upsampling mode for ADPCM.", MainWindow.CLog.CItem.EMode.Command, "ADPCM"));
                    res.Add(new MainWindow.CLog.CItem("                   0=Nearest neighbor interpolation, 1=Linear interpolation, 2=Cubic spline interpolation."));
                    res.Add(new MainWindow.CLog.CItem("BOSPDXHQ [ON|OFF]  Sets to use the high-quality version of bos.pdx.", MainWindow.CLog.CItem.EMode.Command, "BOSPDXHQ"));
                    res.Add(new MainWindow.CLog.CItem("MXFADE             Start fades out.", MainWindow.CLog.CItem.EMode.Command, "MXFADE"));
                    res.Add(new MainWindow.CLog.CItem("MXLOOP [Num]       Sets the number of loops.", MainWindow.CLog.CItem.EMode.Command, "MXLOOP"));
                    res.Add(new MainWindow.CLog.CItem("MXMUTE [Channel]   Toggles channel mute. [1-16|A-H|P-W|ALL]", MainWindow.CLog.CItem.EMode.Command, "MXMUTE"));
                    res.Add(new MainWindow.CLog.CItem("MXOPM [ON|OFF]     Sets to enable OPM output.", MainWindow.CLog.CItem.EMode.Command, "MXOPM"));
                    res.Add(new MainWindow.CLog.CItem("MXPCM [ON|OFF]     Sets to enable PCM(PCM8) output.", MainWindow.CLog.CItem.EMode.Command, "MXPCM"));
                    res.Add(new MainWindow.CLog.CItem("MXP [Filename]     Plays the specified MDX file. (The extension can be omitted.)", MainWindow.CLog.CItem.EMode.Command, "MXP"));
                    res.Add(new MainWindow.CLog.CItem("MXSEEK [Seconds]   Changes the playback position of the playing MDX file.", MainWindow.CLog.CItem.EMode.Command, "MXSEEK"));
                    res.Add(new MainWindow.CLog.CItem("MXSTAT             Displays information about the playing MDX file.", MainWindow.CLog.CItem.EMode.Command, "MXSTAT"));
                    res.Add(new MainWindow.CLog.CItem("MXSTOP             Stops playback.", MainWindow.CLog.CItem.EMode.Command, "MXSTOP"));
                    res.Add(new MainWindow.CLog.CItem("SAMPLERATE [Hz]    Sets the rendering frequency. (62500 to 384000Hz)", MainWindow.CLog.CItem.EMode.Command, "SAMPLERATE"));
                    res.Add(new MainWindow.CLog.CItem(""));
                    res.Add(new MainWindow.CLog.CItem("+ Audio output class"));
                    res.Add(new MainWindow.CLog.CItem("OUTPUT [ON|OFF]    Sets to output Log file and Wave file.", MainWindow.CLog.CItem.EMode.Command, "OUTPUT"));
                    res.Add(new MainWindow.CLog.CItem("VOLUME [dB]        Sets the output volume. (70 to 100dB)", MainWindow.CLog.CItem.EMode.Command, "VOLUME"));
                    res.Add(new MainWindow.CLog.CItem(""));
                    res.Add(new MainWindow.CLog.CItem("Commands and file names are not case sensitive."));
                    res.Add(new MainWindow.CLog.CItem("Only one parameter is allowed, so double quotes are not required for file names with spaces."));
                    break;
                default: throw new Exception();
            }
            return res;
        }

        public enum EMainWindow {
            MenuFile, MenuEditEnv, MenuExit, MenuHelp,
        };
        private static Dictionary<EMainWindow, CItem> MainWindowItems = new() {
            { EMainWindow.MenuFile, new CItem("ファイル(_F)", "File(_F)") },
            { EMainWindow.MenuEditEnv, new CItem("環境設定(_S)", "Settings(_S)") },
            { EMainWindow.MenuExit, new CItem("終了(_X)", "Exit(_X)") },
            { EMainWindow.MenuHelp, new CItem("ヘルプ(_H)", "Help(_H)") },
        };
        public static string GetMainWindow(EMainWindow e) {
            if (MainWindowItems.ContainsKey(e)) { return MainWindowItems[e].Get(); }
            return "MainWindow: Language resource undefined.";
        }

        public enum EMDXOnline {
            CantParseEmptyPath, CantMoveToUpFromRoot, CantFoundDirectory,
        };
        private static Dictionary<EMDXOnline, CItem> MDXOnlineItems = new() {
            { EMDXOnline.CantParseEmptyPath, new CItem("空のパスは処理できません。", "Cannot process an empty path.") },
            { EMDXOnline.CantMoveToUpFromRoot, new CItem("ルートより上のディレクトリには移動できません。", "Cannot move to a directory above the root.") },
            { EMDXOnline.CantFoundDirectory, new CItem("ディレクトリが見つかりません。", "Directory not found.") },
        };
        public static string GetMDXOnline(EMDXOnline e) {
            if (MDXOnlineItems.ContainsKey(e)) { return MDXOnlineItems[e].Get(); }
            return "MDXOnline: Language resource undefined.";
        }

        public enum EMXDRV {
            CanIgnoreException_Ignored, CanIgnoreException_Stopped,
            RepeatParamError,
            RepeatEndNotStarted, RepeatExitNotStarted, FadeoutParamError, UndefCommand, CommandSwitchError, SetOPMNoiseChError, UndefPCMVoiceNote, FadeoutStarted,
            SyncSignalOverChOutOfRange_Wait, SyncSignalOverChOutOfRange_Send, SyncSignalWaitOnWaiting, SyncSignalNoWaitOnNoWaiting,
            NoMDXFormatFile_StartWith0x00, NotFoundPDX, PerformEnded, UsePDXHQBos, EnableOldVolumeTable,
            MDXPDXReader_StringOverflow,
            Voice_NotFoundVoiceData, Voice_VolumeError,
            PDX_UndefPCMFormat, PDX_IlligalVolumeForOldMDXWinVolumeTable, PDX_VolumeError, PDX_IlligalPCMNum,
            PDXHQBos_OnlySupportMonoCh, PDXHQBos_OnlySupport1624bits, PDXHQBos_UnpackZipError, PDXHQBos_InternalError_CPCMWithNoRenderPCM, PDXHQBos_InternalError_BosPdxWithAnotherPCMFormat,
            UnsupportPhaseLFOType, UnsupportAmpLFOType,
            X68Sound_UnsupportFreqConversion,
        };
        private static Dictionary<EMXDRV, CItem> MXDRVItems = new() {
            { EMXDRV.CanIgnoreException_Ignored, new CItem("続行可能な例外を無視しました。", "Ignored a continuable exception.") },
            { EMXDRV.CanIgnoreException_Stopped, new CItem("続行可能な例外で停止しました。", "Stopped by a continuable exception.") },
            { EMXDRV.RepeatParamError, new CItem("リピート開始パラメータ異常", "Repeat start parameter error") },
            { EMXDRV.RepeatEndNotStarted, new CItem("リピート開始していないのにリピート終端が来た", "Repeat end without repeat start") },
            { EMXDRV.RepeatExitNotStarted, new CItem("リピート開始していないのにリピート脱出が来た", "Repeat escape without repeat start") },
            { EMXDRV.FadeoutParamError, new CItem("フェードアウトパラメータ異常", "Fade out parameter error") },
            { EMXDRV.UndefCommand, new CItem("未定義命令", "Undefined instruction") },
            { EMXDRV.CommandSwitchError, new CItem("ここには来ないはず。CommandのSwitch例外", "Should not come here. Command switch exception") },
            { EMXDRV.SetOPMNoiseChError, new CItem("OPMノイズ周波数設定チャネル異常", "OPM noise frequency setting channel error") },
            { EMXDRV.UndefPCMVoiceNote, new CItem("未登録のPCM番号です。", "Unregistered PCM number.") },
            { EMXDRV.FadeoutStarted, new CItem("フェードアウトを開始しました。", "Started fade out.") },
            { EMXDRV.SyncSignalOverChOutOfRange_Wait, new CItem("同期信号 待機 Ch範囲外", "Sync signal wait [standby] out of channel range") },
            { EMXDRV.SyncSignalOverChOutOfRange_Send, new CItem("同期信号 解除 Ch範囲外", "Sync signal release [Cancellation] out of channel range") },
            { EMXDRV.SyncSignalWaitOnWaiting, new CItem("同期信号を待機中なのに、待機命令が来た。", "Wait command while waiting for sync signal.") },
            { EMXDRV.SyncSignalNoWaitOnNoWaiting, new CItem("同期信号を待っていないのに、解除信号が来た。", "Release signal without waiting for sync signal.") },
            { EMXDRV.NoMDXFormatFile_StartWith0x00, new CItem("MDXファイルではない。（先頭バイトが0x00）", "Not an MDX file. (First byte is 0x00)") },
            { EMXDRV.NotFoundPDX, new CItem("PDXファイルが見つかりませんでした。", "PDX file not found.") },
            { EMXDRV.PerformEnded, new CItem("演奏が終了しています。", "Playback has ended.") },
            { EMXDRV.UsePDXHQBos, new CItem("高音質版bos.pdxを使用しています。", "Using high-quality version of bos.pdx.") },
            { EMXDRV.EnableOldVolumeTable, new CItem("古いMDXWinの音量テーブルが有効になっています。", "Old MDXWin volume table is enabled.") },
            { EMXDRV.MDXPDXReader_StringOverflow, new CItem("最大文字数オーバー", "Exceeded maximum number of characters.") },
            { EMXDRV.Voice_NotFoundVoiceData, new CItem("音色データが見つかりません。", "Voice data not found.") },
            { EMXDRV.Voice_VolumeError, new CItem("ボリューム値異常", "Abnormal volume value") },
            { EMXDRV.PDX_UndefPCMFormat , new CItem("未対応PCMフォーマット", "Unsupported PCM format") },
            { EMXDRV.PDX_IlligalVolumeForOldMDXWinVolumeTable, new CItem("(このメッセージは表示されないはずです) 古いMDXWin用に作った自作MDXファイルのPCM8の@vコマンドは、vコマンドを事前に@vに変換しているはず", "(This message should not appear.) The @v command of PCM8 in the homemade MDX file for the old MDXWin should have converted the v command to @v beforehand.") },
            { EMXDRV.PDX_VolumeError, new CItem("ボリューム値異常", "Abnormal volume value") },
            { EMXDRV.PDX_IlligalPCMNum, new CItem("異常なPCM番号です。", "Abnormal PCM number.") },
            { EMXDRV.PDXHQBos_OnlySupportMonoCh, new CItem("モノラルチャネルのみ対応しています。", "Only supports monaural channels.") },
            { EMXDRV.PDXHQBos_OnlySupport1624bits, new CItem("16/24bitsのみ対応しています。", "Only supports 16/24bits.") },
            { EMXDRV.PDXHQBos_UnpackZipError, new CItem("ZIP展開に失敗しました。", "Failed to unzip ZIP.") },
            { EMXDRV.PDXHQBos_InternalError_CPCMWithNoRenderPCM, new CItem("RenderPCMを作成しないで、CPCMを作成しようとした。", "Tried to create CPCM without creating RenderPCM.") },
            { EMXDRV.PDXHQBos_InternalError_BosPdxWithAnotherPCMFormat, new CItem("bos.pdxをADPCM以外で再生しようとした。", "Tried to play bos.pdx with something other than ADPCM.") },
            { EMXDRV.UnsupportPhaseLFOType, new CItem("未対応のソフトPhaseLFOタイプです。", "Unsupported software PhaseLFO type.") },
            { EMXDRV.UnsupportAmpLFOType, new CItem("未対応のソフトAmpLFOタイプです。", "Unsupported software AmpLFO type.") },
            { EMXDRV.X68Sound_UnsupportFreqConversion, new CItem("周波数変換未対応", "Frequency conversion not supported") },
        };
        public static string GetMXDRV(EMXDRV e) {
            if (MXDRVItems.ContainsKey(e)) { return MXDRVItems[e].Get(); }
            return "MXDRV: Language resource undefined.";
        }

        public enum EMDXDis {
            VoiceNotFound,
            CS_SetTempo, CS_WriteReg, CS_SetVoice, CS_SetPanpot, CS_SetVolume, CS_VolumeMinus, CS_VolumePlus, CS_SetQ, CS_DisableKeyOff, CS_RepeatStart, CS_RepeatEnd, CS_RepeatExit, CS_SetDetune, CS_SetPorta, CS_DataEnd, CS_SetKeyOnDelay, CS_SendSync, CS_WaitSync, CS_SetADPCM, CS_SetPhaseLFO, CS_SetAmpLFO, CS_SetOPMLFO, CS_SetLFODelay, CS_EnablePCM8, CS_StartFadeout, CS_Error,
            RepeatParamError, FadeoutParamError, UndefCmd_InterruptDis, CommandSwitchError,
        };
        private static Dictionary<EMDXDis, CItem> MDXDisItems = new() {
            { EMDXDis.VoiceNotFound, new CItem("音色が見つからなかった。", "Voice not found.") },
            { EMDXDis.CS_SetTempo, new CItem("テンポ設定", "Set tempo") },
            { EMDXDis.CS_WriteReg, new CItem("OPMレジスタ設定", "Set OPM register") },
            { EMDXDis.CS_SetVoice, new CItem("音色設定", "Set voice") },
            { EMDXDis.CS_SetPanpot, new CItem("出力位相設定", "Set panpot") },
            { EMDXDis.CS_SetVolume, new CItem("音量設定", "Set volume") },
            { EMDXDis.CS_VolumeMinus, new CItem("音量減小", "Decrease volume") },
            { EMDXDis.CS_VolumePlus, new CItem("音量増大", "Increase volume") },
            { EMDXDis.CS_SetQ, new CItem("発音長指定", "Set quantize") },
            { EMDXDis.CS_DisableKeyOff, new CItem("キーオフ無効", "Disable key off") },
            { EMDXDis.CS_RepeatStart, new CItem("リピート開始", "Repeat start") },
            { EMDXDis.CS_RepeatEnd, new CItem("リピート終端", "Repeat end") },
            { EMDXDis.CS_RepeatExit, new CItem("リピート脱出", "Repeat escape") },
            { EMDXDis.CS_SetDetune, new CItem("デチューン", "Set detune") },
            { EMDXDis.CS_SetPorta, new CItem("ポルタメント", "Set portamento") },
            { EMDXDis.CS_DataEnd, new CItem("データエンド", "Data end") },
            { EMDXDis.CS_SetKeyOnDelay, new CItem("キーオンディレイ", "Key on delay") },
            { EMDXDis.CS_SendSync, new CItem("同期信号送出", "Send sync signal") },
            { EMDXDis.CS_WaitSync, new CItem("同期信号待機", "Wait for sync signal") },
            { EMDXDis.CS_SetADPCM, new CItem("ADPCM/ノイズ周波数設定", "Set ADPCM or noise frequency") },
            { EMDXDis.CS_SetPhaseLFO, new CItem("音程LFO制御", "Set PhaseLFO") },
            { EMDXDis.CS_SetAmpLFO, new CItem("音量LFO制御", "Set AmpLFO") },
            { EMDXDis.CS_SetOPMLFO, new CItem("OPMLFO制御", "Set OPMLFO") },
            { EMDXDis.CS_SetLFODelay, new CItem("LFOディレイ設定(SoftLFOのみ)", "Set LFO delay (only for SoftLFO)") },
            { EMDXDis.CS_EnablePCM8, new CItem("PCM8拡張モード移行", "Switch to PCM8 extended mode") },
            { EMDXDis.CS_StartFadeout, new CItem("フェードアウト", "Start fade out") },
            { EMDXDis.CS_Error, new CItem("ここには来ないはず:", "Should not come here:") },
            { EMDXDis.RepeatParamError, new CItem("リピート開始パラメータ異常", "Repeat start parameter error") },
            { EMDXDis.FadeoutParamError, new CItem("フェードアウトパラメータ異常", "Fade out parameter error") },
            { EMDXDis.UndefCmd_InterruptDis, new CItem("未定義命令 解析中断", "Undefined instruction analysis abort") },
            { EMDXDis.CommandSwitchError, new CItem("CommandのSwitch例外", "Command switch exception") },
        };
        public static string GetMDXDis(EMDXDis e) {
            if (MDXDisItems.ContainsKey(e)) { return MDXDisItems[e].Get(); }
            return "MDXDis: Language resource undefined.";
        }

        public enum EDirect3D {
            Hardware_CantInit, Wrap_CantInit, Software_CantInit, Reference_CantInit, CantInit
        };
        private static Dictionary<EDirect3D, CItem> Direct3DItems = new() {
            { EDirect3D.Hardware_CantInit, new CItem("Direct3D Hardware を初期化できませんでした。 ", "Failed to initialize Direct3D Hardware.") },
            { EDirect3D.Wrap_CantInit, new CItem("Direct3D Warp を初期化できませんでした。 ", "Failed to initialize Direct3D Warp.") },
            { EDirect3D.Software_CantInit, new CItem("Direct3D Software を初期化できませんでした。 ", "Failed to initialize Direct3D Software.") },
            { EDirect3D.Reference_CantInit, new CItem("Direct3D Reference を初期化できませんでした。 ", "Failed to initialize Direct3D Reference.") },
            { EDirect3D.CantInit, new CItem("Direct3Dを初期化できませんでした。", "Failed to initialize Direct3D.") },
        };
        public static string GetDirect3D(EDirect3D e) {
            if (Direct3DItems.ContainsKey(e)) { return Direct3DItems[e].Get(); }
            return "Direct3D: Language resource undefined.";
        }

        public enum EWDocView {
            FileNotLoaded, MDXDisError, PDXDisError, SaveAs_FilterName, SaveAs_Title,
        };
        private static Dictionary<EWDocView, CItem> WDocViewItems = new() {
            { EWDocView.FileNotLoaded, new CItem("ファイルが読み込まれていません。", "No file is loaded.") },
            { EWDocView.MDXDisError, new CItem("MDXファイルの解析中にエラーが発生しました。", "An error occurred while analyzing the MDX file.") },
            { EWDocView.PDXDisError, new CItem("PDXファイルの解析中にエラーが発生しました。", "An error occurred while analyzing the PDX file.") },
            { EWDocView.SaveAs_FilterName, new CItem("ZIPファイル", "ZIP files") },
            { EWDocView.SaveAs_Title, new CItem("名前を付けて保存する", "Save as") },
        };
        public static string GetWDocView(EWDocView e) {
            if (WDocViewItems.ContainsKey(e)) { return WDocViewItems[e].Get(); }
            return "WDocView: Language resource undefined.";
        }
    }
}
