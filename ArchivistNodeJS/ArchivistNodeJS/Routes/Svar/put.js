var svar = require("../../Models/Svar");
const bodyParser = require('body-parser').json();

module.exports = (req, res) => {
    
    var svarToSave = new svar(req.body);

    svar.collection.findOneAndReplace({ svar: req.params.svar }, { svarToSave }, function (err) {
        if (err) {
            res.send(err);
        } else {
            res.status(201).json(svarToSave);
        }
    });
};