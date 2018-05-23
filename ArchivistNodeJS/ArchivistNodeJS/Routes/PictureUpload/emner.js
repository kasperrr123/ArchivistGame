const pictures = require('express').Router();
const bodyParser = require('body-parser').json();
const formidable = require("formidable");
const util = require('util');
const fs = require('fs-extra');
var multiparty = require('multiparty');
var busboy = require('connect-busboy');

module.exports = pictures.post('/', (req, res) => {
    var form = new formidable.IncomingForm();
    form.parse(req, function (err, fields, files) {
        var oldpath = files.file.path;
        var newpath = __dirname + '/Emner/' + files.file.name;
        fs.rename(oldpath, newpath, function (err) {
            if (err) console.log(err);
            res.status(200).json('localhost:3000/' + files.file.name);
        });
    });
});