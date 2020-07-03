import React from 'react';
import './Filepicker.css';
import axios from 'axios';
import Fileinput from '../input/Fileinput';

export default class Filepicker extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            selectFile: null,
        }

    }
    onChangeHandler = event => {

        this.setState({
            selectFile: event.target.files[0],
            loaded: 0,
        });

    }


    onClickHandler = (config) => {
        const data = new FormData()

        data.append('file', this.state.selectFile);
        data.append('config', config)

        axios.post("http://localhost:8000/upload", data, {

        })
            .then(res => {
                console.log(res.statusText)
            })
    }

    print = () => {
        console.log("hello world")
    }

    render() {
        return (
            <div className="file-container">
                <div className="upload-container">
                    <label>Upload your file !</label>
                    <input className="upload" type="file" name="file" onChange={this.onChangeHandler} />
                </div>
                <Fileinput upload={this.onClickHandler}/>
                <div type="button" className="button-click" onClick={() => this.onClickHandler}>Upload</div>
            </div>
        )
    }
}