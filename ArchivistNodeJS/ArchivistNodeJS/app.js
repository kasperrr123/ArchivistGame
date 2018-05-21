const app = require('express')();
const routes = require('./Routes');
const mongoose = require('mongoose');
const bodyParser = require('body-parser');
const busboy = require('connect-busboy');


var allowCrossDomain = function (req, res, next) {
    res.header('Access-Control-Allow-Origin', 'http://localhost:4200');
    res.header('Access-Control-Allow-Methods', 'GET,PUT,POST,DELETE');
    res.header('Access-Control-Allow-Headers', 'Content-Type');
    next();
}

var urlencode = bodyParser.urlencoded({ extended: true });

app.use(bodyParser.json());

app.use(busboy());
app.use(allowCrossDomain);

mongoose.connect('mongodb://localhost:27017/ArchivistGame')


routes.use(function (req, res, next) {
    next();
});

//  Connect all our routes to our application
app.use('/', routes);


// Turn on that server!
app.listen(3000, () => {
    console.log('App listening on port 3000');
});
