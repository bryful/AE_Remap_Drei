//------------------------------------------------------
function setLayerRemap(ex)
{
	//***************************
	//ターゲット
	this.atvCmp = app.project.activeItem;
	if (this.atvCmp == null){
		this.selLyr = null;
		this.frameRate = 24;
	}else{
		this.selLyr = app.project.activeItem.selectedLayers;
		this.frameRate = this.atvCmp.frameRate;
	}

	//データを獲得
	this.excd = ex;
	this.targetCell = -1;
	this.keyCount = 0;
	this.cells = new Array;
	this.range = null;
	if (this.excd !=null) {
		if (this.excd.targetCell >=0){
			this.targetCell = this.excd.targetCell;
			this.keyCount = this.excd.keyCount(this.targetCell);
			if (this.keyCount>0) {
				for ( var i=0; i<this.keyCount; i++)
				{
					var o = new Object;
					var t = this.excd.cellData[this.targetCell][i];
					o.frame = t.frame / this.frameRate;
					if (t.num <1)
					{
						o.num = -1;
					}else{
						o.num = (t.num - 1) / this.frameRate;
					}
					this.cells.push(o);
				}
			}
			this.range = this.excd.getCellRange(this.targetCell);
		}
	}
	//***************************
	this.remapSet = function(lyr)
	{
		if ( lyr == null) {
			return;
		}
		var myRemap = lyr.timeRemap;
		lyr.timeRemapEnabled = true;
		//余計なキーフレームを削除
		if (myRemap.numKeys>=2) {
			for (var i=myRemap.numKeys; i>=2; i--){
				myRemap.removeKey(i);
			}
		}
		var emp = lyr.source.duration;
		for (var i=0; i<this.keyCount; i++){
			if (this.cells[i].num<0)
			{
				myRemap.setValueAtTime(this.cells[i].frame, emp);
			}else{
				myRemap.setValueAtTime(this.cells[i].frame, this.cells[i].num);
			}
		}
		//キーフレームを停止させる
		for (var i=1 ; i<=myRemap.numKeys ; i++){
			myRemap.setInterpolationTypeAtKey(i,KeyframeInterpolationType.HOLD,KeyframeInterpolationType.HOLD);
		}
		//
		lyr.inPoint = this.range.start / this.frameRate;
		lyr.outPoint = this.range.last / this.frameRate;

	}
	//***************************
	this.run = function()
	{
		if (this.atvCmp == null){
			alert("何か選択してください。");
			return;
		}
		//選択されているレイヤが無かったら、終了。
		if ( ( this.selLyr == null )||( this.selLyr.length<=0 ) ) {
			alert("レイヤを選択してください。");
			return;
		}
		
		if (this.keyCount<=0) {
			alert("セルデータがありません。");
			return;
		}
		for ( var i=0; i<this.selLyr.length; i++)
		{
			this.remapSet(this.selLyr[i]);
		}
	}
	//***************************
}

var AE_Remap_Exec = new setLayerRemap(Exceed);

AE_Remap_Exec.run();

