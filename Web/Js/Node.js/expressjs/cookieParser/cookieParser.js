var express      = require('express');
var cookieParser = require('cookie-parser');
var app = express();
app.use(cookieParser());

app.get('/', function(req, res) {
    console.log('Cookies: ', req.cookies)
});

app.listen(8080);

// curl command that sends an HTTP request with two cookies
// curl http://127.0.0.1:8080 --cookie "Cho=Kim;Greet=Hello"