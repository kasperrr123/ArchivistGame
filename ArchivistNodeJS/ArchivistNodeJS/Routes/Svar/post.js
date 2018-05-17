const svare = require('express').Router();
const svar = require('../../Models/Svar');
const bodyParser = require('body-parser').json();

module.exports = svare.post('/', bodyParser, (req, res) => {

    var svarToSave = new svar(req.body);
    svarToSave.save(function (err) {
        if (err) {
            res.send(err);
        } else {
            res.status(201).json(svarToSave);
        }
    });
});