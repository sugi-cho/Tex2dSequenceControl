# Tex2D Sequence Control

Generating `Texture2DArray` from sequential textures

![sequential](sequential_textures.jpg)

![timeline](tex2d_seq.gif)

control via `Timeline`

## 透過動画を表示したい時に使うと、

- 連番テクスチャをテクスチャシート化しなくてよい
- アルファ付き動画に変換しなくてよい
- 複製したシークエンスを低負荷で、それぞれのタイミングで再生することができる
  
`Texture2DArray`全体分のテクスチャデータをGPUメモリ上に載せる必要がある
