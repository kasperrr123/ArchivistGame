var mongoose = require("mongoose");
var schema = mongoose.Schema;

var emneSchema = new schema({
    emne: String,
    beskrivelse: String,
    antalBrugt: Number,
    billede: String,
});

module.exports = mongoose.model('Emne', emneSchema);