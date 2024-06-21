"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const express_1 = __importDefault(require("express"));
const body_parser_1 = __importDefault(require("body-parser"));
const service_route_1 = __importDefault(require("./routes/service.route"));
class Server {
    constructor() {
        this.app = (0, express_1.default)();
        this.port = 3000;
        this.initializeMiddlewares();
        this.initializeRoutes();
    }
    initializeMiddlewares() {
        this.app.use(body_parser_1.default.json());
        this.app.get('/', (req, res) => {
            res.send(`Backend is running on port ${this.port}`);
        });
    }
    initializeRoutes() {
        this.app.use('/', service_route_1.default);
    }
    start() {
        this.app.listen(this.port, () => {
            console.log(`Server is Running on http://localhost:${this.port}`);
        });
    }
}
const server = new Server();
server.start();
