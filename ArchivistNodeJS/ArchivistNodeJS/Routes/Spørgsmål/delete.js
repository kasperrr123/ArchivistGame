const spørgsmåls = require('express').Router();
var spørgsmål = require("../../Models/Spørgsmål");
const bodyParser = require('body-parser').json();

module.exports = spørgsmåls.delete('/', (req, res) => {

    var spørgsmålToDelete = new spørgsmål(req.body);

    spørgsmål.deleteOne({ spørgsmål: spørgsmålToDelete.spørgsmål }, function (err) {
        if (!err) {
            res.status(204).json({ 'Success': 'Deleted document' })
        } else {
            res.status(500).json({ 'Error': 'Contact an admin' })
        }
    })

});