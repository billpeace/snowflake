const webpack = require("webpack")
const path = require("path")

function DtsBundlePlugin(){}
DtsBundlePlugin.prototype.apply = function (compiler) {
  compiler.plugin('done', function(){
    let dts = require('dts-bundle');

    dts.bundle({
      name: "snowflake",
      main: 'dist/types/index.d.ts',
      out: '../snowflake.d.ts',
      removeSource: true,
      outputAsModuleFolder: true // to use npm in-package typings,
    });
  });
};

module.exports = {
    entry: [
        "./src/index.ts",
    ],

    output: {
        path: path.join(__dirname, "dist"),
        filename: "snowflake.js",
        publicPath: "/static/",
        library: "snowflake",
        libraryTarget: "commonjs-module"
    },

    // Enable sourcemaps for debugging webpack's output.
    devtool: "source-map",

    resolve: {
        // Add '.ts' and '.tsx' as resolvable extensions.
        extensions: [".ts", ".tsx", ".js"],
    },

    plugins: [
        new webpack.DefinePlugin({
            "process.env": {
                "NODE_ENV": JSON.stringify("production")
            }
        }),
        new DtsBundlePlugin(),
    ],
    module: {
        rules: [{
            test: /\.tsx?$/,
            exclude: path.resolve(__dirname, "node_modules"),
            include: path.resolve(__dirname, "src"),
            use: [{
                loader: "ts-loader",
            }],
        }],
    },
    node: {
        console: false,
        global: true,
        process: true,
    },
    // When importing a module whose path matches one of the following, just
    // assume a corresponding global variable exists and use that instead.
    // This is important because it allows us to avoid bundling all of our
    // dependencies, which allows browsers to cache those libraries between builds.
    externals: {

    },

};