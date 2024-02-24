// TestPage.jsx
import React, { useState, useEffect } from 'react';
import { FormControlLabel, Radio } from '@mui/material';
import { useParams } from 'react-router-dom';
import axios from 'axios';

const TestPage = ({ userId }) => { 
    const [detail, setDetail] = useState(null);
    const [totalMarks, setTotalMarks] = useState(null);
    const [showResults, setShowResults] = useState(false);
    const [selectedAnswers, setSelectedAnswers] = useState({});

    const { id } = useParams();

    useEffect(() => {
        getTest();
    }, []);

    const getTest = async () => {
        try {
            const response = await axios.get(`http://localhost:5109/api/Tests/${id}`);
            console.log(response.data);
            setDetail(response.data);
            if (!Object.keys(selectedAnswers).length && response.data) {
                const initialSelectedAnswers = {};
                response.data.Questions.forEach(question => {
                    initialSelectedAnswers[question.IdQuestion] = null;
                });
                setSelectedAnswers(initialSelectedAnswers);
            }
        } catch (error) {
            console.error(error);
        }
    };

    const handleAnswerChange = (questionId, answerId) => {
        setSelectedAnswers(prevSelectedAnswers => ({
            ...prevSelectedAnswers,
            [questionId]: answerId
        }));
    };

    const calculateTestMarks = () => {
        let sum = 0;
        if (detail) {
            detail.Questions.forEach(question => {
                const selectedAnswerId = selectedAnswers[question.IdQuestion];
                if (selectedAnswerId !== null) {
                    const selectedAnswer = question.Answers.find(answer => answer.Id === selectedAnswerId);
                    if (selectedAnswer) {
                        sum += selectedAnswer.Mark;
                    }
                }
            });
        }
        setTotalMarks(sum);
    };

    const handleViewResult = async () => {
        calculateTestMarks();
        setShowResults(true);

        // try {
        //     // Send a POST request to submit the completed test
        //     await axios.post(`http://localhost:5109/api/CompletedTests?testId=${id}&userId=${userId}`);
        // } catch (error) {
        //     console.error('Error submitting completed test:', error);
        // }
    };

    return (
        <div>
            <p>Test ID: {id}</p>
            <p>Test ID: {userId}</p>

            <h2>Questions for Test: {detail && detail.NameTest}</h2>

            <div className="items-container">
                {detail && detail.Questions.map(question => (
                    <div key={question.IdQuestion} className="work-section-info">
                        <h3>{question.Question1}</h3>
                        <ul>
                            {question.Answers.map(answer => (
                                <FormControlLabel
                                    key={answer.Id}
                                    control={<Radio />}
                                    label={answer.Question}
                                    onChange={() => handleAnswerChange(question.IdQuestion, answer.Id)}
                                />
                            ))}
                        </ul>
                    </div>
                ))}
            </div>
            <button className="secondary-button-item" onClick={handleViewResult}>
                View Result
            </button>
            {showResults && typeof totalMarks === 'number' && <p>Total Marks: {totalMarks}</p>}
        </div>
    );
};

export default TestPage;
