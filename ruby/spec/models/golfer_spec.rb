require 'spec_helper'

describe Golfer do
  it "should create a new golfer" do
    joe = Golfer.new("Joe")
    expect(joe).to be_kind_of(Golfer)
    expect(joe.name).to eq("Joe")
  end

  it "should require a golfer's name" do
    expect(Golfer.new(nil)).to raise_error
  end  
end
