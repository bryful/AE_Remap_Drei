//JavaScript
//最初の行は"//JavaScript"としてヘッダとする。
//クリップボードから読み込んだ時の識別用。
//---------------------------------------------------------------
var <RX> = new Object;
//---------------------------------------------------------------
//変数の定義
<RX>.enabled	= false;
<RX>.targetCell	= <targetCell>;	//選択されているレイヤ
<RX>.cellCount	= <cellCount>;	//セルレイヤ数
<RX>.frameCount	= <frameCount>;	//フレーム数
<RX>.frameRate	= <frameRate>;	//フレームレート

<RX>.cellCaption	= [<RX>.cellCount];	//セル名の配列
<RX>.cellData		= [<RX>.cellCount];	//セルデータの配列
// object.frame	フレーム数
// object.num	セル番号。0スタート　空セルはマイナス値

<RX>.keyCount 		= [<RX>.cellCount];	//各セルのキーフレームデータの要素数の
<RX>.cellRange		= [<RX>.cellCount];	//各セルのin点/out点の配列
// object.start
// object.last

//---------------------------------------------------------------
//キャプション作成
function setCaption(idx,cap)
{
	<RX>.cellCaption[idx] = cap;
};
<cellCaptionData>


//---------------------------------------------------------------
//セルデータを作成
//cellCount分の配列を作成
for (var i = 0; i<<RX>.cellCount; i++){
	<RX>.cellData[i] = new Array;
}
function setKeyData (idx,frm,num)
{
	if ( (idx<0)||(idx>=<RX>.cellCount) ) return;
	var ret = new Object;
	ret.frame = frm;
	ret.num = num - 1;
	<RX>.cellData[idx].push(ret);
}
<cellData>

//-------------------------------------------------------
//セルデータの要素数をリストアップ
for (var i = 0; i<<RX>.cellCount; i++){
	if ( <RX>.cellData[idx] == null) {
		<RX>.keyCount[i] = 0;
	}else{
		<RX>.keyCount[i] = <RX>.cellData[i].length;
	}
}

//---------------------------------------------------------------
//レイヤのin点/out点を求める
function getCellRange(idx)
{
	var ret = new Object;
	ret.start = 0;
	ret.last = -1;
	if ( (idx<0)||(idx>=<RX>.cellCount) ) return ret;
	if ( ( <RX>.cellData[idx] == null)||(<RX>.cellData[idx].length<=0) ) return ret;
	var cnt = <RX>.cellData[idx].length;
	for( var i=0; i< cnt; i++)
	{
		if ( <RX>.cellData[idx][i].num >= 0 ) {
			ret.start = <RX>.cellData[idx][i].frame;
			break;
		}
	}
	if ( <RX>.cellData[idx][cnt-1].num < 0)
	{
		ret.last = <RX>.cellData[idx][cnt-1].frame;
	}else{
		ret.last = <RX>.frameCount;
	}
	return ret;
}
for (var i = 0; i< <RX>.cellCount; i++){
{
	<RX>.cellRange[i] = getCellRange(i);
}
//---------------------------------------------------------------


<userScript>
