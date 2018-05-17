var mongoose = require("mongoose");
var schema = mongoose.Schema;

var scoreboardSchema = new schema({
    spillernavn: String,
    emne: String,
    resultat: String,
    point: Number
});

module.exports = mongoose.model('Scoreboard', scoreboardSchema);