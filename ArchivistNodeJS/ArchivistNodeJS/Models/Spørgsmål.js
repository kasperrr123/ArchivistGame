var mongoose = require("mongoose");
var schema = mongoose.Schema;

var spørgsmålSchema = new schema({
    spørgsmål: String,
    emne: String,
    billede: { data: Buffer, contentType: String }
});

module.exports = mongoose.model('Spørgsmål', spørgsmålSchema);