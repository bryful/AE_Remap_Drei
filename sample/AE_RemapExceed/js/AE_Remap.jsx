//JavaScript
//Scriptサポート用の雛形スクリプト
//
function AE_Ramap()
{
	this.targetCell	= $targetCell;
	this.cellCount	= $cellCount;
	this.frameCount	= $frameCount;
	
	this.cellCaption	= [this.cellCount];
	this.cellData	= [this.cellCount];
	this.cellRange	= [this.cellCount];
	
	//CellCount分の配列を作成
	for (var i = 0; i<this.cellCount; i++){
		this.cellData[i] = new Array;
	}
	//--------------
	//登録用の関数
	this.newKeyData = function (idx,frm,num)
	{
		var ret = new Object;
		ret.frame = frm;
		ret.num = num;
		this.cellData[idx].push(ret);
	}
	//--------------
	//キーフレームの数を得る
	this.keyCount = function(idx)
	{
		return this.cellData[idx].length;
	}
	//--------------
	//レイヤ名を獲得
	this.caption = function(idx)
	{
		return this.cellCaption[idx];
	}
	//--------------
	//レイヤの範囲を調べる
	this.getCellRange = function(idx)
	{
		var ret = new Object;
		ret.start = -1;
		ret.last = -1;
		if ( (idx<0)||(idx>=this.cellCount) ) return ret;
		if ( ( this.cellData[idx] == null)||(this.cellData[idx].length<=0) ) return ret;
		var cnt = this.cellData[idx].length;
		for( var i=0; i< cnt; i++)
		{
			if ( this.cellData[idx][i].num > 0 ) {
				ret.start = this.cellData[idx][i].frame;
				break;
			}
		}
		if ( this.cellData[idx][cnt-1].num == 0)
		{
			ret.last = this.cellData[idx][cnt-1].frame;
		}else{
			ret.last = this.frameCount;
		}
		return ret;
	}
	//--------------
	//セルデータを登録
	//this.CellCaption[0] ="";
$cellCaptionData
	//this.newKeyData( 0, 1, 1);
$cellData

	for ( var i=0; i<this.cellCount; i++)
	{
		this.cellRange[i] = this.getCellRange(i);
	}
}
//クラスを作成
var Exceed = new AE_Ramap();

$userScript
