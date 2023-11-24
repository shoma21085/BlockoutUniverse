# 色々な設定方法（メモ）

## TextMesh Proでフォントを追加する方法

1. Window→TextMesh Pro→Font Asset CreaterからTextMeshProをインポートする
2. Assets/TextMesh Pro/Fontにフォントファイル(*.ttf)をドロップする
3. もう一度Font Asset Createrを開く
4. 以下の項目を設定してGenerate Font Alansを押す

・Source Font Fileをドロップしたフォントファイルにする

・Samplimg point SizeにCustom Font Sizeを選択して48にする

・Paddingを5にする

・Packing Methodを高速にする

・Atalas Resolutionを両方とも8192にする

・Character SetをCustom Charactersにする

5. Assets/TextMesh Pro/Fontディレクトリを選択してSaveを押す
6. 作成したフォントファイル(*.asset)を選択する
7. Generate SettingのAtlas Population Modeという項目をDyanamicにする
8. Fallback Font AssetsのFallback Listの＋を押し、作成したフォントファイル(*.asset)を選択する

## Sliderの設定方法

1. GameObject→UI→Sliderから追加する
2. つまみの部分であるHandle Slide Areaはいらなければ削除する
3. Sliderの子オブジェクトFill AreaのLeft, Rightを0にする
4. Fill Areaの子オブジェクトFillのLeft, rightを0にする
5. Sliderの子オブジェクトBackGroundのColorでスライドバーの背景色を変更する
6. FillのColorでスライドバーの色を変更する
7. FillのSource ImageをNoneにすると四角バーになる
