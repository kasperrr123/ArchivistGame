var scoreboard = require("../../Models/Scoreboard");
const scoreboards = require('express').Router();

module.exports = scoreboards.get('/', (req, res) => {
    scoreboard.find({}, { _id: 0, __v: 0 },function (err, scores) {
        if (err) {
            res.send(err);
        } else {
            res.status(200).json(scores);
        }
    });
});