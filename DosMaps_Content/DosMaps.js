var toHighlight1 = [{id: ".us", value: 1000},{id: ".ar",value: 501},{id: ".ch",value: 10}]; //get json from server_daniel
var toHighlight2 = [{id: ".ch", value: 1000},{id: ".kr",value: 501},{id: ".md",value: 10}]; //get json from server_daniel
var toHighlight3 = [{id: ".al", value: 1000},{id: ".ru",value: 501},{id: ".vn",value: 10}]; //get json from server_daniel
var blank = [{id: ".ad", value: 1000},{id: ".ae", value: 1000},{id: ".af", value: 1000},{id: ".ag", value: 1000},{id: ".ai", value: 1000},{id: ".al", value: 1000},{id: ".am", value: 1000},{id: ".ao", value: 1000},{id: ".aq", value: 1000},{id: ".ar", value: 1000},{id: ".as", value: 1000},{id: ".at", value: 1000},{id: ".au", value: 1000},{id: ".aw", value: 1000},{id: ".ax", value: 1000},{id: ".az", value: 1000},{id: ".ba", value: 1000},{id: ".bb", value: 1000},{id: ".bd", value: 1000},{id: ".be", value: 1000},{id: ".bf", value: 1000},{id: ".bg", value: 1000},{id: ".bh", value: 1000},{id: ".bi", value: 1000},{id: ".bj", value: 1000},{id: ".bl", value: 1000},{id: ".bm", value: 1000},{id: ".bn", value: 1000},{id: ".bo", value: 1000},{id: ".bq", value: 1000},{id: ".br", value: 1000},{id: ".bs", value: 1000},{id: ".bt", value: 1000},{id: ".bv", value: 1000},{id: ".bw", value: 1000},{id: ".by", value: 1000},{id: ".bz", value: 1000},{id: ".ca", value: 1000},{id: ".cc", value: 1000},{id: ".cd", value: 1000},{id: ".cf", value: 1000},{id: ".cg", value: 1000},{id: ".ch", value: 1000},{id: ".ci", value: 1000},{id: ".ck", value: 1000},{id: ".cl", value: 1000},{id: ".cm", value: 1000},{id: ".cn", value: 1000},{id: ".co", value: 1000},{id: ".cr", value: 1000},{id: ".cu", value: 1000},{id: ".cv", value: 1000},{id: ".cw", value: 1000},{id: ".cx", value: 1000},{id: ".cy", value: 1000},{id: ".cz", value: 1000},{id: ".de", value: 1000},{id: ".dj", value: 1000},{id: ".dk", value: 1000},{id: ".dm", value: 1000},{id: ".do", value: 1000},{id: ".dz", value: 1000},{id: ".ec", value: 1000},{id: ".ee", value: 1000},{id: ".eg", value: 1000},{id: ".eh", value: 1000},{id: ".er", value: 1000},{id: ".es", value: 1000},{id: ".et", value: 1000},{id: ".fi", value: 1000},{id: ".fj", value: 1000},{id: ".fk", value: 1000},{id: ".fm", value: 1000},{id: ".fo", value: 1000},{id: ".fr", value: 1000},{id: ".ga", value: 1000},{id: ".gb", value: 1000},{id: ".uk", value: 1000},{id: ".gd", value: 1000},{id: ".ge", value: 1000},{id: ".gf", value: 1000},{id: ".gg", value: 1000},{id: ".gh", value: 1000},{id: ".gi", value: 1000},{id: ".gl", value: 1000},{id: ".gm", value: 1000},{id: ".gn", value: 1000},{id: ".gp", value: 1000},{id: ".gq", value: 1000},{id: ".gr", value: 1000},{id: ".gs", value: 1000},{id: ".gt", value: 1000},{id: ".gu", value: 1000},{id: ".gw", value: 1000},{id: ".gy", value: 1000},{id: ".hk", value: 1000},{id: ".hm", value: 1000},{id: ".hn", value: 1000},{id: ".hr", value: 1000},{id: ".ht", value: 1000},{id: ".hu", value: 1000},{id: ".id", value: 1000},{id: ".ie", value: 1000},{id: ".il", value: 1000},{id: ".im", value: 1000},{id: ".in", value: 1000},{id: ".io", value: 1000},{id: ".iq", value: 1000},{id: ".ir", value: 1000},{id: ".is", value: 1000},{id: ".it", value: 1000},{id: ".je", value: 1000},{id: ".jm", value: 1000},{id: ".jo", value: 1000},{id: ".jp", value: 1000},{id: ".ke", value: 1000},{id: ".kg", value: 1000},{id: ".kh", value: 1000},{id: ".ki", value: 1000},{id: ".km", value: 1000},{id: ".kn", value: 1000},{id: ".kp", value: 1000},{id: ".kr", value: 1000},{id: ".kw", value: 1000},{id: ".ky", value: 1000},{id: ".kz", value: 1000},{id: ".la", value: 1000},{id: ".lb", value: 1000},{id: ".lc", value: 1000},{id: ".li", value: 1000},{id: ".lk", value: 1000},{id: ".lr", value: 1000},{id: ".ls", value: 1000},{id: ".lt", value: 1000},{id: ".lu", value: 1000},{id: ".lv", value: 1000},{id: ".ly", value: 1000},{id: ".ma", value: 1000},{id: ".mc", value: 1000},{id: ".md", value: 1000},{id: ".me", value: 1000},{id: ".mf", value: 1000},{id: ".mg", value: 1000},{id: ".mh", value: 1000},{id: ".mk", value: 1000},{id: ".ml", value: 1000},{id: ".mm", value: 1000},{id: ".mn", value: 1000},{id: ".mo", value: 1000},{id: ".mp", value: 1000},{id: ".mq", value: 1000},{id: ".mr", value: 1000},{id: ".ms", value: 1000},{id: ".mt", value: 1000},{id: ".mu", value: 1000},{id: ".mv", value: 1000},{id: ".mw", value: 1000},{id: ".mx", value: 1000},{id: ".my", value: 1000},{id: ".mz", value: 1000},{id: ".na", value: 1000},{id: ".nc", value: 1000},{id: ".ne", value: 1000},{id: ".nf", value: 1000},{id: ".ng", value: 1000},{id: ".ni", value: 1000},{id: ".nl", value: 1000},{id: ".no", value: 1000},{id: ".np", value: 1000},{id: ".nr", value: 1000},{id: ".nu", value: 1000},{id: ".nz", value: 1000},{id: ".om", value: 1000},{id: ".pa", value: 1000},{id: ".pe", value: 1000},{id: ".pf", value: 1000},{id: ".pg", value: 1000},{id: ".ph", value: 1000},{id: ".pk", value: 1000},{id: ".pl", value: 1000},{id: ".pm", value: 1000},{id: ".pn", value: 1000},{id: ".pr", value: 1000},{id: ".ps", value: 1000},{id: ".pt", value: 1000},{id: ".pw", value: 1000},{id: ".py", value: 1000},{id: ".qa", value: 1000},{id: ".re", value: 1000},{id: ".ro", value: 1000},{id: ".rs", value: 1000},{id: ".ru", value: 1000},{id: ".rw", value: 1000},{id: ".sa", value: 1000},{id: ".sb", value: 1000},{id: ".sc", value: 1000},{id: ".sd", value: 1000},{id: ".se", value: 1000},{id: ".sg", value: 1000},{id: ".sh", value: 1000},{id: ".si", value: 1000},{id: ".sj", value: 1000},{id: ".sk", value: 1000},{id: ".sl", value: 1000},{id: ".sm", value: 1000},{id: ".sn", value: 1000},{id: ".so", value: 1000},{id: ".sr", value: 1000},{id: ".ss", value: 1000},{id: ".st", value: 1000},{id: ".sv", value: 1000},{id: ".sx", value: 1000},{id: ".sy", value: 1000},{id: ".sz", value: 1000},{id: ".tc", value: 1000},{id: ".td", value: 1000},{id: ".tf", value: 1000},{id: ".tg", value: 1000},{id: ".th", value: 1000},{id: ".tj", value: 1000},{id: ".tk", value: 1000},{id: ".tl", value: 1000},{id: ".tm", value: 1000},{id: ".tn", value: 1000},{id: ".to", value: 1000},{id: ".tr", value: 1000},{id: ".tt", value: 1000},{id: ".tv", value: 1000},{id: ".tw", value: 1000},{id: ".tz", value: 1000},{id: ".ua", value: 1000},{id: ".ug", value: 1000},{id: ".um", value: 1000},{id: ".us", value: 1000},{id: ".uy", value: 1000},{id: ".uz", value: 1000},{id: ".va", value: 1000},{id: ".vc", value: 1000},{id: ".ve", value: 1000},{id: ".vg", value: 1000},{id: ".vi", value: 1000},{id: ".vn", value: 1000},{id: ".vu", value: 1000},{id: ".wf", value: 1000},{id: ".ws", value: 1000},{id: ".ye", value: 1000},{id: ".yt", value: 1000},{id: ".za", value: 1000},{id: ".zm", value: 1000},{id: ".zw", value: 1000}]
$(document).ready(function() {	
	$(".continents").change(function(){
		$("#perspective").removeClass().addClass($(this).val());
	});
	
	$("form input:radio").change(function(){
		if ($(this).val() == "c/p"){
			highlight(toHighlight1);
		}else if ($(this).val() == "pf"){
			highlight(toHighlight2);
		}else if ($(this).val() == "rpf"){
			highlight(toHighlight3);
		}
	})
	
	$("#perspective").click(function() {
        $("#svg").css("width",(parseInt($("#svg").css("width"))+30).toString()+"px");
        $("#svg").css("height",(parseInt($("#svg").css("height"))+30).toString()+"px");
		
        $("#svg").css("margin-left",(parseInt($("#svg").css("margin-left"))-10).toString()+"px");
        $("#svg").css("margin-top",(parseInt($("#svg").css("margin-top"))-10).toString()+"px");
    })
	
	$("#perspective").dblclick(function() {
        $("#svg").css("width",(parseInt($("#svg").css("width"))+30).toString()+"px");
        $("#svg").css("height",(parseInt($("#svg").css("height"))+30).toString()+"px");
		
        $("#svg").css("margin-left",(parseInt($("#svg").css("margin-left"))-10).toString()+"px");
        $("#svg").css("margin-top",(parseInt($("#svg").css("margin-top"))-10).toString()+"px");
    })
	
	$(".map").load("Map.svg");
	
})

function highlight(toHighlight){
	allToBrown(blank);
	var ends = findEnds(toHighlight);
		//alert(ends[0] + " " + ends[1]);
		for (var i = 0; i< toHighlight.length; i++){
			//alert(getColor(toHighlight[i].value, ends));
			$(toHighlight[i].id).css("fill",getColor(toHighlight[i].value, ends));
		}
}
function allToBrown(toHighlight){
	for (var i = 0; i< toHighlight.length; i++){
			//alert(getColor(toHighlight[i].value, ends));
			$(toHighlight[i].id).css("fill","#897b4c")
		}
}
//http://stackoverflow.com/questions/10756313/javascript-jquery-map-a-range-of-numbers-to-another-range-of-numbers
Number.prototype.map=function(in_min, in_max, out_min, out_max) {
	return (this - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
}

$(document).ready(function() {
	$(".highlight").click(function(event){
		//showPrayerNeeded();
		highlight(toHighlight);
	})
	
	$(".continents").change(function(){
		$("#perspective").removeClass().addClass($(this).val());
	});
	
	$("#perspective").click(function() {
        $("#svg").css("width",(parseInt($("#svg").css("width"))+30).toString()+"px");
        $("#svg").css("height",(parseInt($("#svg").css("height"))+30).toString()+"px");
		
        $("#svg").css("margin-left",(parseInt($("#svg").css("margin-left"))-10).toString()+"px");
        $("#svg").css("margin-top",(parseInt($("#svg").css("margin-top"))-10).toString()+"px");
    })
	
	$(".map").load("Map.svg");
	
})

//http://stackoverflow.com/questions/15042887/min-and-max-in-multidimensional-array
function findEnds(arr){
	var xVals = arr.map(function(obj) { return obj.value; });
	var min = Math.min.apply(null, xVals);
	var max = Math.max.apply(null, xVals);
	
	return [min,max];
}

function getColor(num, ends){
	if (ends[0] != ends[1]){
		var mapped = num.map(ends[0],ends[1],0,400);
	}else{
		var mapped = num.map(ends[0]-1,ends[1],0,400);
	}
	if (mapped<200){
			return "#0000"+(0+(mapped+50).toString(16)).toUpperCase().slice(-2);
	}else{
		return "#"+(0+((mapped-200).toString(16)).toUpperCase()).slice(-2)+(0+((mapped-200).toString(16)).toUpperCase()).slice(-2)+"FF";
	}
}
	
//http://stackoverflow.com/questions/15042887/min-and-max-in-multidimensional-array
function findEnds(arr){
	var xVals = arr.map(function(obj) { return obj.value; });
	var min = Math.min.apply(null, xVals);
	var max = Math.max.apply(null, xVals);
	
	return [min,max];
}

function getColor(num, ends){
	if (ends[0] != ends[1]){
		var mapped = num.map(ends[0],ends[1],0,400);
	}else{
		var mapped = num.map(ends[0]-1,ends[1],0,400);
	}
	if (mapped<200){
		return "#0000"+(0+(mapped+50).toString(16)).toUpperCase().slice(-2);
	}else{
		return "#"+(0+((mapped-200).toString(16)).toUpperCase()).slice(-2)+(0+((mapped-200).toString(16)).toUpperCase()).slice(-2)+"FF";
	}
}