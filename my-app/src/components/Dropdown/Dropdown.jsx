import React from 'react';
import '../Dropdown/Dropdown.css';
import Select from 'react-select';
import Fileinput from '../input/Fileinput';
import Fileinput2 from '../input/FIleinput2';

const options = [
    { value: 'Person', label: 'Person' },
    { value: 'Course', label: 'Course' },
];

export default class Dropdown extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            selectionOption: null,
        }
    }
    
    handelchange = selectionOption => {
        this.setState(
            { selectionOption },
            () => console.log('Option selected:', this.state.selectionOption)
        );
        this.props.toggleClass()
    };
   
    render() {
        return (
            <div className="input-container">
                <table>
                    <tbody>
                        <tr>
                            <td><Select
                                value={this.state.selectionOption}
                                onChange={ this.handelchange}
                                options={options}
                            /></td>
                        </tr>
                    </tbody>
                </table>
            </div>


        )

    }
}