var scoreboard = require("../../Models/Scoreboard");
const bodyParser = require('body-parser').json();

module.exports = (req, res) => {
    
    var scoreboardToSave = new scoreboard(req.body);

    scoreboard.collection.findOneAndReplace({ emne: req.params.scoreboard }, { scoreboardToSave }, function (err) {
        if (err) {
            res.send(err);
        } else {
            res.status(201).json(scoreboardToSave);
        }
    });
};