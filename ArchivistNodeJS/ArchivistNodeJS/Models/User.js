var mongoose = require("mongoose");
var schema = mongoose.Schema;

var userSchema = new schema({
    username: String,
    password: String,
    admin: Boolean,
});

module.exports = mongoose.model('User', userSchema);