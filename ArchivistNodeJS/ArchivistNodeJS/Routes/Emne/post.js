const emner = require('express').Router();
const emne = require('../../Models/Emne');
const bodyParser = require('body-parser').json();

module.exports = emner.post('/', bodyParser, (req, res) => {

    var emneToSave = new emne(req.body);
    emneToSave.save(function (err) {
        if (err) {
            res.send(err);
        } else {
            res.status(201).json(emneToSave);
        }
    });
});