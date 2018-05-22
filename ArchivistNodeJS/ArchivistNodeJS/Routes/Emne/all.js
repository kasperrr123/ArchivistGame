var emne = require("../../Models/Emne");
const emner = require('express').Router();

module.exports = emner.get('/', (req, res) => {
    emne.find({}, { _id: 0, __v: 0 },function (err, topics) {
        if (err) {
            res.send(err);
        } else {
            res.status(200).json(topics);
        }
    });
});