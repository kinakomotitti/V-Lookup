# V-Lookup

## 背景

ExcelのVLOOKUP関数を使いたいけど、対象のファイルがたくさんあって、一つ一つ設定するのがめんどくさい！！！
というシチュエーションがあったのでつくってみました。

---
想定しているシナリオ（問題あり版）
1. Excel開く
2. Vlookup関数入力する
3. 結果をまとめる
4. ファイルの数だけ1.から繰り返し処理する

--- 
想定しているシナリオ（問題解決版）
1. ファイルの数だけループする処理を作成（batファイルなどを想定）。  
ループ処理の中でvlookup　コマンドを実行する。
2. 1.のbatファイルを実行する。
--- 

## ロードマップ（ざっくり）

まずは、以下の２つの機能の完成を目標として作業を進めています。
①オリジナルのVLOOKUP機能
②指定した列で特定できる行の、指定した列の差分を検出する機能

上記機能完成後は、アウトプット先のバリエーションを増やしていこうと思います。
具体的には、基本出力（標準出力、テキストファイル）に加え、  
DB（postgres）や、そのたのリソースへの出力を検討しています。
