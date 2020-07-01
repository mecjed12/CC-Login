import React from 'react';
import './Fileinput.css';
import Select from 'react-select';

const options = [
    { value: 'Zeile 1', label: 'Zeile 1' },
    { value: 'Zeile 2', label: 'Zeile 2' },
    { value: 'Zeile 3', label: 'Zeile 3' },
  ];

export default class Fileinput extends React.Component {
   state = {
       selectedOption: null,
       selectedOption1: null,
       selectedOption2: null,
   };
   handleChange = selectedOption => {
       this.setState({ selectedOption});
       console.log('Option selected:', selectedOption);
   };
   handleChange1 = selectedOption1 => {
    this.setState({ selectedOption1});
    console.log('Option selected:', selectedOption1);
};
handleChange2 = selectedOption2 => {
    this.setState({ selectedOption2});
    console.log('Option selected:', selectedOption2);
};
      
    render() {
        const { selectedOption} = this.state;
        const { selectedOption1} = this.state;
        const { selectedOption2} = this.state;
        
        return(
            <div className="input-container">
                <table>
                    <tr>
                        <th></th>
                        <th></th>
                    </tr>
                    <tr>
                        <td>ID</td>
                        <td> <Select
                      value= {selectedOption}
                      onChange={this.handleChange}
                      options={options}
                      /></td>
                        
                    </tr>
                    <tr>
                        <td>Firstname</td>
                        <td> <Select
                      value= {selectedOption1}
                      onChange={this.handleChange1}
                      options={options}
                      /></td>
                    </tr>
                    <tr>
                        <td>Lastname</td>
                        <td> <Select
                      value= {selectedOption2}
                      onChange={this.handleChange2}
                      options={options}
                      /></td>
                    </tr>
                </table>
                
               
                
            </div>
        )
    }
}