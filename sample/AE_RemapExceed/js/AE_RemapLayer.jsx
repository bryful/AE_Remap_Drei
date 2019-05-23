//JavaScript
//******************************************************************
//最初の行は"//JavaScript"としてヘッダとする。
//クリップボードから読み込んだ時の識別用。
//******************************************************************
var <RX> = new Object;
//******************************************************************
//変数の定義
<RX>.enabled	= false;
<RX>.frameCount	= <frameCount>;	//フレーム数
<RX>.frameRate	= <frameRate>;	//フレームレート
<RX>.caption	= <caption>;
<RX>.cellData	= new Array;	//セル番号
/*
	object.frame フレーム番号（0スタート）
	object.num セル番号（0スタート。-1は空セル）
*/
<RX>.usedBlind		= <usedBlind>;

<RX>.blindData		= new Array;	//ブラインドエフェクト用の配列
/*
	object.frame フレーム番号（0スタート）
	object.blind 透明フラグ（0が不透明、100が透明）
*/

<RX>.inF		= 0;			//レイヤのin点(フレーム)
<RX>.outF		= <frameCount>;	//レイヤのout点(フレーム)

<RX>.memodData		= new Array;	//ブラインドエフェクト用の配列


<RX>.targetComp		= null;
<RX>.targetLayers	= null;
<RX>.frameRateComp	= <frameRate>;
<RX>.errMes = "";

//******************************************************************
<RX>.init  =function()
{
	this.enabled	= false;
	this.targetComp = null;
	this.targetLayers = null;
	this.targetFrameRate	= <frameRate>;
	var cmp = app.project.activeItem;
	if ( ( cmp != null)&& ( cmp instanceof CompItem ) ){
		this.targetLayers = app.project.activeItem.selectedLayers;
		if ( (this.targetLayers != null)&&( this.targetLayers.length>0)) {
			this.targetComp = cmp;
			this.frameRateComp = cmp.frameRate;

			if ( this.frameRateComp != this.frameRate ){
				this.errMes += "illegal frameRate!\n";
			}else{
				this.enabled = true;
			}
		}
	}
}
//******************************************************************
<RX>.setKeyData = function(frm,num)
{
	var ret = new Object;
	ret.frame = frm;
	ret.num = num -1;//セルは１スタートなので0にする
	this.cellData.push(ret);
}
//<RX>.setKeyData(frm,num);
<cellData>

//******************************************************************
<RX>.setMemo = function(frm,memo)
{
	if ( memo != "" ){
		var ret = new Object;
		ret.frame = frm;
		ret.memo = memo;
		this.memoData.push(ret);
	}
}
//<RX>.setMemo(frm,memo);
<memoData>
//******************************************************************
//ブラインドエフェクト用の配列を作成
if ( ( <RX>.cellData.length > 1)&&(<RX>.usedBlind == true) ){
	var o = new Object;
	o.frame = <RX>.cellData[0].frame;
	if (<RX>.cellData[0].num>=0) {
		o.blind = 0;
	}else{
		o.blind = 100;
	}
	<RX>.blindData.push(o);
	var mae = o.blind;
	for (var i=1; i< <RX>.cellData.length; i++){
		if (<RX>.cellData[i].num>=0) {
			var ima = 0;
		}else{
			var ima = 100;
		}
		if (mae != ima) {
			var o = new Object;
			o.frame = <RX>.cellData[i].frame;
			o.blind = ima;
			<RX>.blindData.push(o);
			mae = ima;
		}
	}
	//
	if ( <RX>.blindData.length == 1) {
		if ( <RX>.blindData[0].blind == 0) <RX>.blindData = new Array;
	}
}
//******************************************************************
//レイヤのin点/out点を求める
if ( ( <RX>.cellData != null)&&(<RX>.cellData.length>0) ) {
	var cnt = <RX>.cellData.length;
	for( var i=0; i< cnt; i++)
	{
		if ( <RX>.cellData[i].num >= 0 ) {
			<RX>.inF = <RX>.cellData[i].frame;
			break;
		}
	}
	if ( <RX>.cellData[cnt-1].num < 0)
	{
		<RX>.outF = <RX>.cellData[cnt-1].frame;
	}
}
//******************************************************************
<RX>.blindSetup = function()
{
	if ( app.language == Language.ENGLISH){
		this.effect_str	= "Effects";
		this.effect_Name = "Venetian Blinds";
		this.effect_PName = "ransition Completion";
	}else{
		this.effect_str	= "エフェクト";
		this.effect_Name = "ブラインド";
		this.effect_PName = "変換終了";
	}
}
//******************************************************************
<RX>.fineBlindEffect = function()
{
	this.blindSetup();
	var fxg = this.targetLayer.property(this.effect_str);
	var fx = fxg.property(this.effect_Name);
	if (fx == null) {
		if (fxg.canAddProperty(this.effect_Name)) {
			fx = fxg.addProperty(this.effect_Name);
		}
	}
	if ( fx!= null) {
		return fx.property(this.effect_PName);
	}else{
		return "";
	}
}
//******************************************************************
<RX>.removeBlindEffect = function()
{
	this.blindSetup();
	var fxg = this.targetLayer.property(this.effect_str);
	if (fxg != null) {
		var fx = fxg.property(this.effect_Name);
		if (fx!= null) {
			fx.remove();
		}
	}
}
//******************************************************************
<RX>.remapSet = function(lyr)
{
	if ( lyr == null) {
		return;
	}
	
	var myRemap = lyr.timeRemap;
	var empty = lyr.source.duration;
	this.targetLayer.timeRemapEnabled = true;
	//余計なキーフレームを削除
	if (myRemap.numKeys>=2) {
		for (var i=myRemap.numKeys; i>=2; i--){
			myRemap.removeKey(i);
		}
	}
	for (var i=0; i<this.cellData.length; i++){
		if (this.cellData[i].num<0)
		{
			myRemap.setValueAtTime(this.cellData[i].frame / this.frameRate, empty);
		}else{
			myRemap.setValueAtTime(this.cellData[i].frame / this.frameRate, this.cellData[i].num / this.frameRate);
		}
	}
	//キーフレームを停止させる
	for (var i=1 ; i<=myRemap.numKeys ; i++){
		myRemap.setInterpolationTypeAtKey(i,KeyframeInterpolationType.HOLD,KeyframeInterpolationType.HOLD);
	}

	//ブラインドエフェクトの処理
	if (this.blindData.length>0){
		var bld = this.fineBlindEffect(true);
		for (var i=0; i<this.blindData.length; i++){
			bld.setValueAtTime(this.blindData[i].frame / this.frameRate, this.blindData[i].blind);
		}
		//キーフレームを停止させる
		for (var i=1 ; i<=bld.numKeys ; i++){
			bld.setInterpolationTypeAtKey(i,KeyframeInterpolationType.HOLD,KeyframeInterpolationType.HOLD);
		}
	}else{
		this.removeBlindEffect();
	}
	//
	
	var markerProperty = lyr.property("Marker");
	//コメントがあれば削除
	var header = "!_";
	if ( markerProperty.numKeys>0) {
		for ( var i=markerProperty.numKeys ; i>=1.length; i--){
			var cmt = markerProperty.keyValue(i).comment;
			if ( cmt.indexOf(header) == 0) {
				markerProperty.removeKey(i); // コメントには必ずheaderを入れておく。それを目安に削除する
			}
		}
	
	}
	if ( this.memoDate.length>0){
		for ( var i=0; i<this.memoDate.length; i++){
			markerProperty.setValueAtTime(this.memoData[i].frame / this.frameRate , new MarkerValue(header+this.memoData[i].memo) );
		}
	
	}
	
	
	lyr.inPoint = this.inF / this.frameRate;
	lyr.outPoint = this.outF / this.frameRate;
}


//******************************************************************
<RX>.run = function()
{
	this.init();
	if ( this.enabled == false) {
		alert("レイヤを選択してください。");
		return;
	}
	if (this.frameRate != this.targetFrameRate)
	{
		alert("フレームレートが一致しません");
		return;
	}

	if ( this.targetComp.duration != (this.frameCount / this.frameRate) ){
		this.targetComp.duration = (this.frameCount / this.frameRate);
	}

	for ( var i=0; i<this.targetLayers.length; i++)
	{
		this.remapSet(this.targetLayers[i]);
	}
}
//******************************************************************

app.beginUndoGroup("AE_Remap Exceed");
<RX>.run();
app.endUndoGroup();

