"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const fs_1 = __importDefault(require("fs"));
const path_1 = __importDefault(require("path"));
class ServiceUtil {
    constructor() {
        this.dbPath = path_1.default.resolve(__dirname, '../db.json');
        this.ensureFileExists();
    }
    ensureFileExists() {
        try {
            if (!fs_1.default.existsSync(this.dbPath)) {
                fs_1.default.writeFileSync(this.dbPath, JSON.stringify([]));
            }
        }
        catch (error) {
            console.error('Error creating JSON file: ', error);
        }
    }
    readJSONFile() {
        try {
            const data = fs_1.default.readFileSync(this.dbPath);
            return JSON.parse(data.toString());
        }
        catch (error) {
            console.error('Error reading JSON file: ', error);
            return [];
        }
    }
    writeJSONFile(data) {
        try {
            fs_1.default.writeFileSync(this.dbPath, JSON.stringify(data, null, 2));
        }
        catch (error) {
            console.error('Error writing to JSON file:', error);
        }
    }
}
exports.default = ServiceUtil;
