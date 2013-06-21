var http = require("http");
var obj;
var hdiff = [];
var haverage;
var hindex;
var handicap;

fs = require('fs');

fs.readFile('scores.json', 'utf8', function (err, data) {
  if (err) throw err;
  obj = JSON.parse(data);
});

http.createServer(function(request, response) {
    response.writeHead(200, {"Content-Type": "text/plain"});
    response.write("Golf Handicap App!\n\n");
    hdiff = [];
    for (var i = 0; i <= 19; i++) {
	hdiff.push(Math.round((((((obj[i].score - obj[i].rating) * 113) / obj[i].slope)))*10)/10);
    }
    hindex = 0;
    haverage = 0;
    hdiff.sort(function(a,b){return a-b});
    for (var i = 0; i <= 9; i++) {
	response.write("Handicap Diff = " + hdiff[i] + "\n");
	haverage = haverage + hdiff[i];
    }
    hindex = (Math.round(((haverage / 10) * 0.96) * 10) / 10);
    response.write("Handicap Index = " + (hindex) + "\n");
    for (var x = 0; x <= 19; x++) {
	response.write("Course Handicap " + (x + 1) + ": " + (Math.round(((hindex * obj[x].slope) / 113) * 10) / 10) + " Net Score: " + Math.round((obj[x].score - ((hindex * obj[x].slope) / 113))) + "\n");
    }
    for (var y = 0; y <= 19; y++) {
	hdiff[i] = 0;
    }
    response.end("Golf Handicap App!");
}).listen(8080);

