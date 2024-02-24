import React, { useState, useEffect } from 'react';
import { FormControlLabel, Radio } from '@mui/material';
import { Link } from 'react-router-dom';
import axios from 'axios';

const AllTest = () => {
    const [tests, setTests] = useState([]);
    const [totalMarks, setTotalMarks] = useState({});
    const [showResults, setShowResults] = useState({});

    useEffect(() => {
        getAllTests();
    }, []);

    const getAllTests = async () => {
        try {
            const response = await axios.get('http://localhost:5109/api/Tests');
            const initialTotalMarks = response.data.reduce((acc, test) => {
                acc[test.Idtest] = 0;
                return acc;
            }, {});
            setTotalMarks(initialTotalMarks);
            setShowResults(Object.fromEntries(response.data.map(test => [test.Idtest, false])));
            setTests(response.data);
        } catch (error) {
            console.error(error);
        }
    };

    const handleAnswerChange = (questionId, answerId, mark, testId) => {
        setTests(prevTests => {
            return prevTests.map(test => {
                if (test.Idtest === testId) {
                    return {
                        ...test,
                        Questions: test.Questions.map(question => {
                            if (question.IdQuestion === questionId) {
                                return {
                                    ...question,
                                    selectedAnswer: answerId
                                };
                            }
                            return question;
                        })
                    };
                }
                return test;
            });
        });
    };

    const calculateTestMarks = (testId) => {
        let sum = 0;
        const test = tests.find(test => test.Idtest === testId);
        if (test) {
            test.Questions.forEach(question => {
                const selectedAnswer = question.Answers.find(answer => answer.Id === question.selectedAnswer);
                if (selectedAnswer) {
                    sum += selectedAnswer.Mark;
                }
            });
        }
        setTotalMarks(prevTotalMarks => ({
            ...prevTotalMarks,
            [testId]: sum
        }));
    };

    const handleViewResult = (testId) => {
        calculateTestMarks(testId);
        setShowResults(prevResults => ({
            ...prevResults,
            [testId]: true
        }));
    };

    return (
        <div>
            <h1>All Tests</h1>
            <div className="items-container">
                {tests.length > 0 ? (
                    <ul>
                        {tests.map(test => (
                            <li key={test.Idtest} className="work-section-info">
                                <h2>{test.NameTest}</h2>
                                <Link to={{ pathname: `/item/${test.Idtest}`, state: { testId: test.Idtest, questions: test.Questions, allTests: tests } }}>Go to Test Page</Link>
                                
                            </li>
                        ))}
                    </ul>
                ) : (
                    <p>No tests available</p>
                )}
            </div>
        </div>
    );
};

export default AllTest;
