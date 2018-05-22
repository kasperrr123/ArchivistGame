const scoreboards = require('express').Router();
const scoreboard = require('../../Models/Emne');
const bodyParser = require('body-parser').json();

module.exports = scoreboards.post('/', bodyParser, (req, res) => {

    var scoreboardToSave = new scoreboard(req.body);
    scoreboardToSave.save(function (err) {
        if (err) {
            res.send(err);
        } else {
            res.status(201).json(scoreboardToSave);
        }
    });
});