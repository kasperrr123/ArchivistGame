const svare = require('express').Router();
var svar = require("../../Models/Svar");
const bodyParser = require('body-parser').json();

module.exports = svare.delete('/', (req, res) => {

    var svarToDelete = new svar(req.body);

    svar.deleteOne({ svar: svarToDelete.svar }, function (err) {
        if (!err) {
            res.status(204).json({ 'Success': 'Deleted document' })
        } else {
            res.status(500).json({ 'Error': 'Contact an admin' })
        }
    })

});