module.exports = {
    plugins: [
        require('postcss-import')({
            "path":"node_modules"
        }),
        require('@fullhuman/postcss-purgecss')({
            content: ["../**/*.{html,cshtml,razor}"],
        }),
        require('postcss-url')([
            { filter: '**/webfonts/*', url: 'copy', assetsPath: '../webfonts', useHash: true },
        ]),
        require('tailwindcss'),
        require('autoprefixer'),
    ]
}