var emne = require("../../Models/Emne");
const bodyParser = require('body-parser').json();

module.exports = (req, res) => {
    
    var emneToSave = new emne(req.body);

    emne.collection.findOneAndReplace({ emne: req.params.emne }, { emneToSave }, function (err) {
        if (err) {
            res.send(err);
        } else {
            res.status(201).json(emneToSave);
        }
    });
};