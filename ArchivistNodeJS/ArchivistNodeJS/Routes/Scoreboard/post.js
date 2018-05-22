const scoreBoards = require('express').Router();
const scoreboard = require('../../Models/Scoreboard');
const bodyParser = require('body-parser').json();

module.exports = scoreBoards.post('/', bodyParser, (req, res) => {

    var scoreboardToSave = new scoreboard(req.body);

    scoreboardToSave.save(function (err) {
        if (err) {
            res.send(err);
        } else {
            res.status(201).json(scoreboardToSave);
        }
    });
});