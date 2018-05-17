var mongoose = require("mongoose");
var schema = mongoose.Schema;

var svarSchema = new schema({
    svar: String,
    spørgsmål: String,
    rigtig: Boolean,
});

module.exports = mongoose.model('Svar', svarSchema);