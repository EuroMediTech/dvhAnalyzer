# dvhAnalyzer

Eclipse (Varian Medical Systems) で利用できるDVH解析用のESAPIプラグインです。

## 使い方

下記操作にて、DVH情報を取得できます。  
![操作方法](img/Movie.gif)

### その他の機能
一度作成したDVH項目はTemplateとして保存可能です。保存したTemplateを読み込む際は、Structure名のマッチング画面が開きます。  
Export機能により、CSVファイルとして出力することができます。

## コンパイル方法

Visual Studioを利用するか、あるいはコマンドラインベースで `DVHAnalyzer.csproj` をコンパイルして使用します。  
ここでは、Visual Studioなしでコンパイルする方法について紹介します。

1. MSBuild.exeを探す  
お使いのWindows (ここではEclipseが搭載されているコンピュータを想定しています) から、MSBuild.exeというプログラムを探します。  
通常は、 `C:\Windows\Microsoft.NET\Framework64\v4.xxxx\MSBuild.exe` に存在しています。  
(v4.xxxxはそれぞれ異なる可能性があります。)

2. このリポジトリをダウンロードする  
画面右上付近にある、Clone or Download という緑色のボタンからDownload ZIPなどを選択し、ローカル環境にダウンロードしてください。  
ZIP形式でダウンロードした場合は適宜解凍してください。

3. コマンドプロンプトを立ち上げてコンパイルを実行する  
手順2でZIP形式でダウンロードして解凍した場合、`dvhAnalyzer-master` というフォルダができているかと思います。  
その中にあるDVHAnalyzerというフォルダ内でコマンドプロンプトを立ち上げ、下記コマンドでコンパイルを実行します。

~~~Batchfile
dvhAnalyzer-master\DVHAnalyzer> C:\Windows\Microsoft.NET\Framework64\v4.xxxx\MSBuild.exe DVHAnalyzer.csproj /p:Configuration=Release
~~~

4. 生成ファイルをEclipse Scriptが実行可能なフォルダに移動する  
上記コマンドがうまくいくと、`obj\x64\Release` というフォルダに `DVHAnalyzer.esapi.dll` というファイルが出来ているはずです。  
こちらをEclipseのExternal Beam PlanningのToolbarにある `Tools -> Scripts` で指定しているフォルダにコピーします。  

5. Eclipseにて線量計算済みのプランを開いて実行する

以上です。  

## Eclipseのバージョンが異なる場合

このプラグインは、Eclipse Ver. 13.7 向けに作成されています。
Ver. 15.1の場合は、上記で使用している `DVHAnalyzer.csproj` を `DVHAnalyzer_v15.1.csproj` に読み替えてください。  
その他のバージョンの場合や、コンパイルがうまくいかない場合は、emt-mediphys@euro-meditec.co.jp までお気軽にお問合せください。