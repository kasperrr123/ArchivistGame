var spørgsmål = require("../../Models/Spørgsmål");
const bodyParser = require('body-parser').json();

module.exports = (req, res) => {
    
    var spørgsmålToSave = new spørgsmål(req.body);

    spørgsmål.collection.findOneAndReplace({ spørgsmål: req.params.spørgsmål }, { spørgsmålToSave }, function (err) {
        if (err) {
            res.send(err);
        } else {
            res.status(201).json(spørgsmålToSave);
        }
    });
};