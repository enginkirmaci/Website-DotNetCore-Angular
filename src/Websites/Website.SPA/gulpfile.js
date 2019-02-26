var gulp = require('gulp');
var Server = require('karma').Server;

// Run test once and exit
gulp.task('default', function (done) {
    new Server({
        configFile: __dirname + '/ClientApp/test/karma.conf.js',
        singleRun: true
    }, done).start();
});