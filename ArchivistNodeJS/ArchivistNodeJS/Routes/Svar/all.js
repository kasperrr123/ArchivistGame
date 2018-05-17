var svar = require("../../Models/Svar");
const svars = require('express').Router();

module.exports = svars.get('/', (req, res) => {
    svar.find({}, { _id: 0, __v: 0 },function (err, svare) {
        if (err) {
            res.send(err);
        } else {
            res.status(200).json(svare);
        }
    });
});