const routes = require('express').Router();

const emne = require('./Emne');
const scoreboard = require('./Scoreboard');
const spørgsmål = require('./Spørgsmål');
const svar = require('./Svar');
const user = require('./User')
const picture = require('./PictureUpload');

routes.use('/emner', emne);
routes.use('/scoreboard', scoreboard);
routes.use('/question', spørgsmål);
routes.use('/svar', svar);
routes.use('/users',user)
routes.use('/UploadPicture',picture);

module.exports = routes;