var gulp = require('gulp'),
    watch = require('gulp-watch'),
    rename = require('gulp-rename');

gulp.task('stream', function () {
    return watch('../../Plugins/**/*.cshtml')
        .pipe(rename(function(path) {
            var viewDirArray = path.dirname.split('\\');
            path.dirname = viewDirArray[viewDirArray.length - 1];
        }))
        .pipe(gulp.dest('./Plugins/Views/'));
});

gulp.task('copyAllViews', function () {

})