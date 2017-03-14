var toHighlight = [{id: ".us", value: 1000},{id: ".ar",value: 500},{id: ".ch",value: 10}]; //get json from server_daniel

$(document).ready(function() {
	$("#highlight").click(function(event){
		var ends = findEnds(toHighlight);
		//alert(ends[0] + " " + ends[1]);
		for (var i = 0; i< toHighlight.length; i++){
			alert(getColor(toHighlight[i].value, ends));
			$(toHighlight[i].id).css("fill",getColor(toHighlight[i].value, ends));
		}
	});
	$(".map").load("Map.svg");
})


//http://stackoverflow.com/questions/10756313/javascript-jquery-map-a-range-of-numbers-to-another-range-of-numbers
Number.prototype.map=function(in_min, in_max, out_min, out_max) {
  return (this - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
}

//http://stackoverflow.com/questions/15042887/min-and-max-in-multidimensional-array
function findEnds(arr){
	var xVals = arr.map(function(obj) { return obj.value; });
	var min = Math.min.apply(null, xVals);
	var max = Math.max.apply(null, xVals);
//	var min = Number.MAX_SAFE_INTEGER;
//	var max = Number.MIN_SAFE_INTEGER;
//	for (var i = 0; i< arr.length; i++){
//		if(arr[i][1]<min){
//			min = arr[i][1];
//		}else if(arr[i][1]>max){
//			max = arr[i][1];
//		}
//	}
	
	return [min,max];
}

function getColor(num, ends){
	if (ends[0] != ends[1]){
		var mapped = (0 + num.map(ends[0],ends[1],0,255).toString(16).toUpperCase()).slice(-2);
	}else{
		var mapped = (0 + num.map(ends[0]-1,ends[1],0,255).toString(16).toUpperCase()).slice(-2);
	}
	if (num < ends[1]/2){
			return "#0000"+mapped;
	}else{
		return "#"+mapped+mapped+"FF";
	}
}