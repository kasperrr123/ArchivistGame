var spørgsmål = require("../../Models/Spørgsmål");
const spørgemåls = require('express').Router();

module.exports = spørgemåls.get('/', (req, res) => {
    spørgsmål.find({}, { _id: 0, __v: 0 },function (err, questions) {
        if (err) {
            res.send(err);
        } else {
            res.status(200).json(questions);
        }
    });
});