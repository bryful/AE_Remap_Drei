//JavaScript
//最初の行は"//JavaScript"としてヘッダとする。
//クリップボードから読み込んだ時の識別用。
//------------------------------------------------------
function setLayerRemap(ex)
{
	//***************************
	//ターゲット
	this.atvCmp = app.project.activeItem;
	if (this.atvCmp == null){
		this.selectedLayers = null;
		this.frameRateS = 24;
	}else{
		this.selectedLayers = app.project.activeItem.selectedLayers;
		this.frameRateS = this.atvCmp.frameRate;
	}

	//変数の定義
	this.frameCount	= <frameCount>;	//フレーム数
	this.frameRate	= <frameRate>;	//フレームレート
	this.caption	= <caption>;

	//---------------------------------------------------------------
	//セルデータを作成
	this.cellData		= new Array;
	//cellCount分の配列を作成
	this.setKeyData = function(frm,num)
	{
		var ret = new Object;
		ret.frame = frm;
		ret.num = num -1;//セルは１スタートトなので
		this.cellData.push(ret);
	}
	//this.setKeyData(frm,num);
<cellData>


	//レイヤのin点/out点を求める
	this.inF	= 0;
	this.outF	= this.frameCount;
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
	}



	//***************************
	this.remapSet = function(lyr)
	{
		if ( lyr == null) {
			return;
		}
		var myRemap = lyr.timeRemap;
		var empty = lyr.source.duration;
		lyr.timeRemapEnabled = true;
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
		//
		lyr.inPoint = this.inF / this.frameRate;
		lyr.outPoint = this.outF / this.frameRate;

	}
	//***************************
	this.run = function()
	{
		if (this.atvCmp == null){
			alert("何か選択してください。");
			return;
		}
		//選択されているレイヤが無かったら、終了。
		if ( ( this.selectedLayers == null )||( this.selectedLayers.length<=0 ) ) {
			alert("レイヤを選択してください。");
			return;
		}
		
		if (this.cellData.length<=0) {
			alert("セルデータがありません。");
			return;
		}
		if (this.frameRate != this.frameRateS)
		{
			alert("フレームレートが一致しません");
			return;
		}
		for ( var i=0; i<this.selectedLayers.length; i++)
		{
			this.remapSet(this.selectedLayers[i]);
		}
	}
	//***************************
}

var AE_Remap_Exec = new setLayerRemap();

AE_Remap_Exec.run();


