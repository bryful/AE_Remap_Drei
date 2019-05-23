//JavaScript
//最初の行は"//JavaScript"としてヘッダとする。
//クリップボードから読み込んだ時の識別用。
//-----------------------------------------------------------------------------
var <RX> = new Object;
//*****************************************************************************
//変数の定義
<RX>.enabled		= false;		//このObjectが有効かどうか
<RX>.activeComp		= null;			//現在アクティブなコンポ
<RX>.selectedLayers	= null;			//現在選択されているレイヤ配列
<RX>.frameRate		= <frameRate>;	//AE_Remapのフレームレート
<RX>.frameRateComp	= 24;			//ターゲットCompのフレームレート
<RX>.frameCount		= <frameCount>;	//フレーム数
<RX>.caption		= <caption>;	//ターゲットレイヤ名
<RX>.inFrame		= 0;			//レイヤのin点(フレーム)
<RX>.outFrame		= <RX>.frameCount;	//レイヤのout点(フレーム)

<RX>.cellData		= new Array;	//セルデータの配列

<RX>.errMes = "";

//*****************************************************************************
<RX>.init = function()
{
	this.enabled = false;
	this.activeComp = app.project.activeItem;
	if (this.activeComp != null) {
		if ( this.activeComp instanceof CompItem){
			this.selectedLayers = app.project.activeItem.selectedLayers;
			this.frameRateComp = this.activeComp.frameRate;
			if ( this.frameRateComp != this.frameRate ){
				this.errMes += "illegal frameRate!\n";
			}else{
				this.enabled = true;
			}
		}else{
			this.selectedLayers = null;
			this.frameRate = 24;
			this.frameRateComp = 24;
			this.errMes += "taget is not CompItem!\n";
		}
	}else{
		this.errMes += "taget is null!\n";
	}
}
//*****************************************************************************
<RX>.setKeyData = function(frm,num)
{
	var ret = new Object;
	ret.frame = frm;
	ret.num = num -1;//セルは１スタートなので
	this.cellData.push(ret);
}

//*****************************************************************************
<RX>.setCellData	= function()
{
	this.cellData		= new Array;
	//cellCount分の配列を作成
	//<RX>.setKeyData(frm,num);

<cellData>

	//レイヤのin点/out点を求める
	this.inF	= 0;
	this.outF	= <RX>.frameCount;
	if ( ( this.cellData != null)&&(this.cellData.length>0) ) {
		var cnt = this.cellData.length;
		for( var i=0; i< cnt; i++)
		{
			if ( this.cellData[i].num >= 0 ) {
				this.inF = this.cellData[i].frame;
				break;
			}
		}
		if ( this.cellData[cnt-1].num < 0)
		{
			this.outF = this.cellData[cnt-1].frame;
		}
	}else{
		this.enabled = false;
		this.errMes += "none cellData!\n";
	}
}
//*****************************************************************************
<RX>.remapSet = function(lyr)
{
	if ( lyr == null) {
		this.errMes += "layer is null!\n";
		return;
	}
	var myRemap = lyr.timeRemap;
	
	//空セル用の数値
	var empty = lyr.source.duration;
	
	lyr.timeRemapEnabled = true;
	//余計なキーフレームを削除
	if (myRemap.numKeys>=2) {
		for (var i=myRemap.numKeys; i>=2; i--){
			myRemap.removeKey(i);
		}
	}
	for (var i=0; i<<RX>.cellData.length; i++){
		if (this.cellData[i].num<0)
		{
			myRemap.setValueAtTime(this.cellData[i].frame / this.frameRate, empty);
		}else{
			myRemap.setValueAtTime(this.cellData[i].frame / this.frameRate, this.cellData[i].num / <RX>.frameRate);
		}
	}
	//キーフレームを停止させる
	for (var i=1 ; i<=myRemap.numKeys ; i++){
		myRemap.setInterpolationTypeAtKey(i,KeyframeInterpolationType.HOLD,KeyframeInterpolationType.HOLD);
	}
	//
	lyr.inPoint = this.inF / this.frameRate;
	lyr.outPoint = this.outF / this.frameRate;

}
//*****************************************************************************
<RX>.run = function()
{
	this.errMes = "";
	this.init();
	if ( this.enabled){
		this.setCellData();
		if ( this.enabled== true){
			for ( var i=0; i<this.selectedLayers.length; i++)
			{
				this.remapSet(this.selectedLayers[i]);
			}
		}
	}
	if ( this.errMes != ""){
		alert(this.errMes);
	}
}
//*****************************************************************************

<RX>.run();