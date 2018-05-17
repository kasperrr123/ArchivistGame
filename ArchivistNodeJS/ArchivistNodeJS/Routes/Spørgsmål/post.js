const spørgmåls = require('express').Router();
const spørgsmål = require('../../Models/Spørgsmål');
const bodyParser = require('body-parser').json();

module.exports = spørgmåls.post('/', bodyParser, (req, res) => {

    var spørgsmålToSave = new spørgsmål(req.body);
    spørgsmålToSave.save(function (err) {
        if (err) {
            res.send(err);
        } else {
            res.status(201).json(spørgsmålToSave);
        }
    });
});