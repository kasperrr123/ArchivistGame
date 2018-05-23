var mongoose = require("mongoose");
var schema = mongoose.Schema;

var spørgsmålSchema = new schema({
    spørgsmål: String,
    fakta:String,
    emne: String,
    billede:String,
});

module.exports = mongoose.model('Spørgsmål', spørgsmålSchema);