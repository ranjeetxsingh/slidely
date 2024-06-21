"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const service_util_1 = __importDefault(require("../utils/service.util"));
class ServiceController {
    constructor() {
        this.ping = (req, res) => {
            res.json({ success: true });
        };
        this.getSubmission = (req, res) => {
            try {
                const submissions = this.serviceUtil.readJSONFile();
                const index = parseInt(req.query.index);
                if (isNaN(index)) {
                    return res.status(404).json({ error: 'Invalid index at Submission' });
                }
                if (index >= 0 && index < submissions.length) {
                    res.json(submissions[index]);
                }
                else {
                    res.status(404).json({ error: 'Submission not found' });
                }
            }
            catch (error) {
                console.error('Error getting submission: ', error);
                res.status(500).json({ error: 'Internal Server Error' });
            }
        };
        this.createSubmission = (req, res) => {
            try {
                const { name, email, phone, github_link, stopwatch_time } = req.body;
                if (!name || !email || !phone || !github_link || !stopwatch_time) {
                    return res.status(400).json({
                        error: 'All fields (name, email, phone, github_link, stopwatch_time) are required',
                    });
                }
                const submissions = this.serviceUtil.readJSONFile();
                const newSubmission = {
                    id: submissions.length + 1,
                    name,
                    email,
                    phone,
                    github_link,
                    stopwatch_time,
                };
                submissions.push(newSubmission);
                this.serviceUtil.writeJSONFile(submissions);
                res.status(201).json(newSubmission);
            }
            catch (error) {
                console.error('Error creating submission:', error);
                res.status(500).json({ error: 'Internal Server Error' });
            }
        };
        this.deleteSubmission = (req, res) => {
            try {
                const index = parseInt(req.query.index);
                if (isNaN(index)) {
                    return res.status(400).json({ error: 'Invalid index' });
                }
                const submissions = this.serviceUtil.readJSONFile();
                if (index >= 0 && index < submissions.length) {
                    const deletedSubmission = submissions.splice(index, 1);
                    submissions.forEach((submission, i) => {
                        submission.id = i + 1;
                    });
                    this.serviceUtil.writeJSONFile(submissions);
                    res.json(deletedSubmission);
                }
                else {
                    res.status(404).json({ error: 'Submission not found' });
                }
            }
            catch (error) {
                console.error('Error deleting submission:', error);
                res.status(500).json({ error: 'Internal Server Error' });
            }
        };
        this.updateSubmission = (req, res) => {
            try {
                const index = parseInt(req.query.index);
                const { name, email, phone, github_link, stopwatch_time } = req.body;
                if (isNaN(index)) {
                    return res.status(400).json({ error: 'Invalid Index' });
                }
                const submission = this.serviceUtil.readJSONFile();
                if (index >= 0 && index < submission.length) {
                    const updatedSubmission = {
                        id: submission[index].id,
                        name: name || submission[index].name,
                        email: email || submission[index].email,
                        phone: phone || submission[index].phone,
                        github_link: github_link || submission[index].github_link,
                        stopwatch_time: stopwatch_time || submission[index].stopwatch_time,
                    };
                    submission[index] = updatedSubmission;
                    this.serviceUtil.writeJSONFile(submission);
                    res.json(updatedSubmission);
                }
                else {
                    res.status(404).json({ error: 'Submission not Found' });
                }
            }
            catch (error) {
                console.error('Error editing submission', error);
                res.status(500).json({ error: 'Internal Server error' });
            }
        };
        this.getReadByEmail = (req, res) => {
            try {
                const { email } = req.body;
                if (!email) {
                    return res.status(400).json({ error: 'Email is required' });
                }
                const submission = this.serviceUtil.readJSONFile();
                const submissionByEmail = submission.filter((submission) => submission.email === email);
                if (submissionByEmail.length === 0) {
                    return res.status(404).json({ error: 'No submission found for the provided email' });
                }
                res.json(submissionByEmail);
            }
            catch (error) {
                console.error('Error getting submissions by email:', error);
                res.status(500).json({ error: 'Internal Server Error' });
            }
        };
        this.serviceUtil = new service_util_1.default();
    }
}
exports.default = ServiceController;
