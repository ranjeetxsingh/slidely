"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const express_1 = require("express");
const service_controller_1 = __importDefault(require("../controllers/service.controller"));
class ServiceRouter {
    constructor() {
        this.router = (0, express_1.Router)();
        this.serviceController = new service_controller_1.default();
        this.initializeRoutes();
    }
    initializeRoutes() {
        this.router.get('/ping', this.serviceController.ping);
        this.router.get('/read', this.serviceController.getSubmission);
        this.router.post('/submit', this.serviceController.createSubmission);
        this.router.delete('/delete', this.serviceController.deleteSubmission);
        this.router.put('/edit', this.serviceController.updateSubmission);
        this.router.post('/read-by-email', this.serviceController.getReadByEmail);
    }
    getRouter() {
        return this.router;
    }
}
exports.default = new ServiceRouter().getRouter();
