const routes = require('express').Router();

const emne = require('./Emne');
const scoreboard = require('./Scoreboard');
const spørgsmål = require('./Spørgsmål');
const svar = require('./Svar');
const user = require('./User')
const picture = require('./PictureUpload');

routes.use('/emner', emne);
routes.use('/scoreboard', scoreboard);
routes.use('/spørgsmål', spørgsmål);
routes.use('/svar', svar);
routes.use('/users',user)
routes.use('/UploadPicture',picture);

routes.get('/', (req, res) => {
    res.status(200).json({ message: 'Connected!' });
});

module.exports = routes;